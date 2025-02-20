﻿namespace Adnc.Maint.Application.Contracts.Dtos;

/// <summary>
/// 操作日志
/// </summary>
public class OpsLogCreationDto : InputDto
{
    /// <summary>
    /// 控制器类名
    /// </summary>
    public string ClassName { get; set; } = string.Empty;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 日志业务名称
    /// </summary>
    public string LogName { get; set; } = string.Empty;

    /// <summary>
    /// 日志类型
    /// </summary>
    public string LogType { get; set; } = string.Empty;

    /// <summary>
    /// 详细信息
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// 控制器方法
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// 是否操作成功
    /// </summary>
    public string Succeed { get; set; } = string.Empty;

    /// <summary>
    /// 操作用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 操作用户账号
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// 操作用户姓名
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 操作用户Ip
    /// </summary>
    public string RemoteIpAddress { get; set; } = string.Empty;
}