﻿using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Autofac;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Adnc.Core.Entities;
using Adnc.Core.IRepositories;
using Adnc.Core;

namespace Adnc.UnitTest
{
    public class EfCoreRepositoryTests : IClassFixture<EfCoreDbcontextFixture>
    {
        //private readonly ITestOutputHelper _output;
        private readonly IMenuRepository _menuRepository;
        private readonly IEfRepository<SysDept> _deptRepository;
        private readonly IEfRepository<SysUser> _userRepository;
        private readonly IEfRepository<SysUserFinance> _userFinanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private EfCoreDbcontextFixture _fixture;

        public EfCoreRepositoryTests(EfCoreDbcontextFixture fixture)
        {
            _fixture = fixture;
            //_output = output;
            _menuRepository = _fixture.Container.Resolve<IMenuRepository>();
            _deptRepository = _fixture.Container.Resolve<IEfRepository<SysDept>>();
            _userRepository = _fixture.Container.Resolve<IEfRepository<SysUser>>();
            _userFinanceRepository = _fixture.Container.Resolve<IEfRepository<SysUserFinance>>();
            _unitOfWork = _fixture.Container.Resolve<IUnitOfWork>();
            _mapper = _fixture.Container.Resolve<IMapper>();
        }

        [Fact]
        public async Task TestConcurrencyCheck()
        {
            //var user1 = await _userRepository.FetchAsync(x => x.ID == 1);
            //user1.Email = "1alphacn@foxmail.com";
            //user1.Sex = 2;
            //UPDATE `SysUser` SET `Email` = @p0, `ModifyTime` = @p1, `Sex` = @p2
            //WHERE `ID` = @p3 AND `RowVersion` = @p4;
            //var result2 = await _userRepository.UpdateAsync(user1, u => u.Email, u => u.Sex);

            var finance = new SysUserFinance
            {
                ID = 4,
                Amount = 450,
                RowVersion = DateTime.Parse("2020-07-01 21:51:12.310")
            };

            //单实体更新(指定列)，有效。
            //var reuslt = await _userFinanceRepository.UpdateAsync(finance, f => f.Amount);
            //Assert.Equal(1, reuslt);

            //单实体更新(不指定列)，有效。
            //var reuslt1 = await _userFinanceRepository.UpdateAsync(finance);
            //Assert.Equal(1, reuslt1);

            //批量更新不能使用到并发字段,我加了逻辑判断，如果存在rowversion列的实体，不能使用该方法。
            var reuslt2 = await _userFinanceRepository.UpdateRangeAsync(u => u.ID == 4, u => new SysUserFinance { Amount = 410 });
            Assert.Equal(1, reuslt2);

        }

        [Fact]
        public async Task TestLoading()
        {
            ////select s.*from sysuer id= 1
            var user1 = await _userRepository.FetchAsync(u=>new { u.ID,u.Dept},x => x.ID == 1);
            Assert.Null(user1.Dept);

            ////select s.* from sysuer id=1
            var user2 = await _userRepository.GetAll().Select(u => u).Where(x => x.ID == 1).FirstOrDefaultAsync();
            Assert.Null(user2.Dept);

            //left join Include Include for Iqueryable
            //预加载，开启了延时加载，延时加载不成功，预加载也会报错
            var user3 = await _userRepository.GetAll().Include(u => u.Dept).Where(u => u.ID == 1).FirstOrDefaultAsync();
            Assert.NotNull(user3.Dept);

            //预加载
            /*
             SELECT `t`.`ID`, `t`.`CreateBy`, `t`.`CreateTime`, `t`.`FullName`, `t`.`ModifyBy`
            , `t`.`ModifyTime`, `t`.`Num`, `t`.`Pid`, `t`.`Pids`, `t`.`SimpleName`
            , `t`.`Tips`, `t`.`Version`, `s0`.`ID`, `s0`.`Account`, `s0`.`Avatar`
            , `s0`.`Birthday`, `s0`.`CreateBy`, `s0`.`CreateTime`, `s0`.`DeptId`, `s0`.`Email`
            , `s0`.`ModifyBy`, `s0`.`ModifyTime`, `s0`.`Name`, `s0`.`Password`, `s0`.`Phone`
            , `s0`.`RoleId`, `s0`.`Salt`, `s0`.`Sex`, `s0`.`Status`, `s0`.`Version`
            FROM (
            SELECT `s`.`ID`, `s`.`CreateBy`, `s`.`CreateTime`, `s`.`FullName`, `s`.`ModifyBy`
            , `s`.`ModifyTime`, `s`.`Num`, `s`.`Pid`, `s`.`Pids`, `s`.`SimpleName`
            , `s`.`Tips`, `s`.`Version`
            FROM `SysDept` `s`
            WHERE `s`.`ID` = 25
            LIMIT 2
            ) `t`
            LEFT JOIN `SysUser` `s0` ON `t`.`ID` = `s0`.`DeptId`
            ORDER BY `t`.`ID`, `s0`.`ID`
            */
            var dept3 = await _deptRepository.GetAll().Include(u => u).Where(u => u.ID >= 25).ToListAsync();
            Assert.NotEmpty(dept3);

            ////指定加载 left join
            var user4 = await _userRepository.GetAll().Where(u => u.ID == 1).Select(u => new SysUser { ID = u.ID, Dept = u.Dept }).FirstOrDefaultAsync();
            Assert.NotNull(user4.Dept);

            //Reference 
            //var user5 = await _userRepository.Table.Select(u => u).Where(x => x.ID == 1).FirstOrDefaultAsync();
            //显示加载报错，因为我关闭了跟踪 
            //Navigation property 'Dept' on entity of type 'SysUser' cannot be loaded because the entity is not being tracked. Navigation properties can only be loaded for tracked entities.
            //await _userRepository.Entry<SysUser>(user5).Reference(p => p.Dept).LoadAsync();
            //Assert.NotNull(user5.Dept);

            //延时加载报错，因为我关闭了跟踪。如果打开跟踪，可以正常加载。
            //An attempt was made to lazy-load navigation property 'Users' on detached entity of type 'SysDept'. Lazy-loading is not supported for detached entities or entities that are loaded with 'AsNoTracking()'. This exception can be suppressed or logged by passing event ID 'CoreEventId.DetachedLazyLoadingWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
            //var dept1 = await _deptRepository.Table.Where(u => u.ID == 25).SingleAsync();
            //Assert.NotEmpty(dept1.Users);

        }

        [Fact]
        public void TestNoTracking()
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking
            var user1 = _userRepository.GetAll().Select(u => u).Where(u => u.ID == 1).FirstOrDefault();
            var result1 = _userRepository.Entry(user1).State;
            Assert.Equal(EntityState.Detached, result1);

            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll
            //var user2 = _userRepository.Table.Select(u => u).Where(u => u.ID == 1).FirstOrDefault();
            //var result2 = _userRepository.Entry(user2).State;
            //Assert.Equal(EntityState.Unchanged, result2);
        }

        [Fact]
        public async Task TestUOW()
        {
            _unitOfWork.BeginTransaction();

            string email = "ads@foxmail.com";

            try
            {
                var user2 = new SysUser
                {
                    ID = 2,
                    Email = email
                };

                var user3 = new SysUser
                {
                    ID = 3,
                    Email = email
                };

                //Ef savechange()
                var result2 = await _userRepository.UpdateAsync(user2, u => u.Email);
                var result3 = await _userRepository.UpdateAsync(user3, u => u.Email);

                //Z.EntityFramework.Plus
                var result4 = await _userRepository.UpdateRangeAsync(x => x.ID >= 4, x => new SysUser { Email = email });

                //Z.EntityFramework.Plus
                var result5 = await _userRepository.DeleteRangeAsync(x => x.ID >= 7);

                //execute raw sql
                var result6 = await _userRepository.DeleteAsync(new[] { 5, 6 });

                throw new Exception("TestUOW");

                //_unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
            }

            Assert.True(true);
        }

        [Fact]
        public async Task TestFetch()
        {
            //var user1 = await _userRepository.FetchAsync(e => new { e.ID, Dept = new { e.Dept.ID, e.Dept.FullName } }, x => x.ID == 2);

            //dynamic userDynamic = new ExpandoObject();
            var a = new
            {
                ID = 2,
                Dept = new
                {
                    ID = 2,
                    FullName = "test"
                }
            };

            dynamic userDynamic = a;


            var user1 = _mapper.Map<SysUser>(userDynamic);

            Assert.NotNull(user1);
         }

        [Fact]
        public async Task TestSelect()
        {
            //_output.WriteLine("This is output from {0}", "EfCoreRepositoryTests");

            //var menus1 = await _menuRepository.SelectAsync(100, q => true, q => q.Levels, true, q => q.Num, true);
            //var menus2 = await _menuRepository.Table.OrderBy(q => q.Levels).ThenBy(q => q.Num).Take(100).ToListAsync();
            //var menus3 = await _menuRepository.GetAsync(q => q.WithPredict(x => true).WithOrderBy(o => o.OrderBy(x => x.Levels).ThenBy(x => x.Num)));
            //var menus4 = await _menuRepository.Table.Take(100).OrderBy(q => q.Levels).ThenBy(q => q.Num).ToListAsync();
            //menus1与menus2,menus1与menus3 sql语句一样，menus3是先取100条再排
            //Assert.NotEmpty(menus1);


            //var user2 = await _userRepository.Table.Select().ToListAsync();
            //SELECT 所以列 FROM `SysUser` AS `s`
            // Assert.NotNull(user2);

            //var user2 = await _userRepository.Table.Select(e => new SysUser() { Email = e.Email, ID = e.ID }).ToListAsync();
            //SELECT `s`.`Email`, `s`.`ID` FROM `SysUser` AS `s`
            // Assert.NotNull(user2);

            var user3 = await _userRepository.GetAll().Select(e => new{ e.Name, e.Dept}).ToListAsync();
            var user4 = await _userRepository.GetAll().Select(e => new SysUser()).FirstOrDefaultAsync();
            //SELECT `s`.`ID`,`s`.`*` FROM `SysUser` AS `s`LEFT JOIN `SysDept` AS `s0` ON `s`.`DeptId` = `s0`.`ID` 左连接了dept表
            //Assert.NotNull(user3);
            //
            //var user4 = await _deptRepository.Table.SelectMany(d => d.SysUser).Where(u=>u.Email==null)ToListAsync();
            //Assert.NotNull(user4);

            //var user5 = await _deptRepository.Table.SelectMany(
            //    d => d.SysUser
            //    , (t, s) => new { t.ID, t.FullName })
            //    .Where(q => q.ID > 4)
            //    .ToListAsync();
            //SELECT `s`.`ID`, `s`.`FullName`FROM `SysDept` AS `s`INNER JOIN `SysUser` AS `s0` ON `s`.`ID` = `s0`.`DeptId` WHERE `s`.`ID` > 4
            //Assert.NotNull(user5);
        }

        [Fact]
        public async Task TestFind()
        {
            //var dept1 = await _deptRepository.FindAsync(new object[] { (long)24 }, CancellationToken.None);
            //Assert.NotNull(dept1);
            var user1 = await _userRepository.FindAsync(new object[] { (long)2 }, CancellationToken.None);
            Assert.NotNull(user1);
        }

        [Fact]
        public async Task TestUpdate()
        {
            //var user1 = await _userRepository.FindAsync(new object[] { (long)3 }, CancellationToken.None);
            var user1 = await _userRepository.FetchAsync(u => new { u.ID, u.Email, u.Sex }, x => x.ID == 1);
            user1.Email = "1alphacn@foxmail.com";
            user1.Sex = 4;

            //sql更新所有字段
            var result1 = await _userRepository.UpdateAsync(user1);
            Assert.Equal(1, result1);

            //sql只更新指定字段
            var result2 = await _userRepository.UpdateAsync(user1, u => u.Email, u => u.Sex);
            Assert.Equal(1, result2);

            //Update sysuser set email = 'alphacn@foxmail.com' where id = 3;
            //Assert.Equal(1, result);

            //var user2 = new SysUser
            //{
            //    ID = 2,
            //    Email = "beta@foxmail.com"
            //};
            //var result2 = await _userRepository.UpdateAsync(user2, u => u.Email);
            ////UPDATE `SysUser` SET `Email` = @p0, `ModifyBy` = @p1, `ModifyTime` = @p2 WHERE `ID` = @p3;
            //Assert.Equal(1, result2);


            //var result3 = await _userRepository.UpdateAsync(q => q.ID > 2, q => q.Sex, 2, CancellationToken.None);
            //Assert.Equal(1, result3);
        }

        [Fact]
        public async Task TestDelete()
        {

            var result1 = await _userRepository.DeleteAsync<long>(new long[] { 5 });
            Assert.Equal(1, result1);

        }
    }
}
