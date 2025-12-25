# v2rayN_Dw

[![CI](https://github.com/adittq/v2rayN_Dw/actions/workflows/ci.yml/badge.svg)](https://github.com/adittq/v2rayN_Dw/actions/workflows/ci.yml)
[![Release](https://img.shields.io/github/v/release/adittq/v2rayN_Dw?sort=semver)](https://github.com/adittq/v2rayN_Dw/releases)

v2rayN_Dw 是基于 v2rayN 的 macOS 可运行封装，提供 App 启动方式、本地 .NET 运行时支持、核心资产路径校正，以及系统代理脚本集成，开箱即可运行。

## 主要特性
- macOS 应用封装：提供 v2rayN.app，双击即可启动
- 启动脚本修复：确保工作目录指向 `net8.0`，避免找不到配置和核心
- 核心资产校正：自动识别 Xray 所需 `geoip.dat`/`geosite.dat`
- 系统代理脚本：集成 macOS 代理设置与清理脚本，退出时自动清理
- 运行日志与问题定位：界面误报与核心运行分离，便于快速排查

## 目录结构
```
v2rayN/
├─ v2rayN-master/                     上游源码目录
│  ├─ v2rayN/v2rayN.Desktop/          Avalonia 桌面工程
│  ├─ ServiceLib/                     业务与核心管理
│  └─ ... 
├─ v2rayN.app/                        macOS 应用封装（本地运行生成）
│  ├─ Contents/MacOS/v2rayN_launcher.sh    启动脚本
│  └─ Contents/Info.plist
├─ .gitignore
└─ README.md
```

## 截图
![v2rayN](v2rayN-master/v2rayN/v2rayN.Desktop/v2rayN.png)

## 快速开始
- 方式一：双击运行
  1. 打开 `v2rayN.app`
  2. 在主界面选择节点并激活
  3. 程序会自动设置系统代理，退出时自动清理

- 方式二：命令行运行
  1. 进入目录：

     ```bash
     cd bin/Debug/net8.0
     ```
  2. 启动：

     ```bash
     dotnet v2rayN.dll
     ```

## 构建与打包
- 本地构建（.NET 8）：

  ```bash
  cd v2rayN-master/v2rayN/v2rayN.Desktop
  dotnet restore
  dotnet build -c Release
  ```

- 发布为 macOS 自包含（示例，按需调整 Runtime Identifier）：

  ```bash
  dotnet publish -c Release -r osx-arm64 --self-contained true
  ```

## 下载
- 稳定版本从 Releases 下载：https://github.com/adittq/v2rayN_Dw/releases
- CI 构建产物在 Actions 的最新工作流运行中获取

## 系统代理脚本
- 设置或清理系统代理（macOS）：

  ```bash
  # 清理代理（断网时恢复直连）
  v2rayN-master/v2rayN/v2rayN.Desktop/bin/Debug/net8.0/binConfigs/proxy_set_osx_sh.sh clear

  # 设置代理（示例：127.0.0.1:10808）
  v2rayN-master/v2rayN/v2rayN.Desktop/bin/Debug/net8.0/binConfigs/proxy_set_osx_sh.sh set 127.0.0.1 10808
  ```

相关代码参考：
- [ProxySettingOSX.cs](file:///Volumes/ITGZ-PCle-4/v2rayN/v2rayN-master/v2rayN/ServiceLib/Handler/SysProxy/ProxySettingOSX.cs)
- [SysProxyHandler.cs](file:///Volumes/ITGZ-PCle-4/v2rayN/v2rayN-master/v2rayN/ServiceLib/Handler/SysProxy/SysProxyHandler.cs)

## 常见问题
- 运行 Core 失败（界面提示）但实际可用：
  - 这是界面层状态检测的误报；若终端或日志显示大量 `[socks -> proxy] accepted`，说明核心已正常转发。
  - 核心启动与校验逻辑见：
    - [CoreManager.cs](file:///Volumes/ITGZ-PCle-4/v2rayN/v2rayN-master/v2rayN/ServiceLib/Manager/CoreManager.cs#L216-L276)

- 延迟始终 -1ms 或无法连接：
  - 检查节点 SNI 是否为有效域名（非备注信息）
  - 清理系统代理后重新启动程序：

    ```bash
    v2rayN-master/v2rayN/v2rayN.Desktop/bin/Debug/net8.0/binConfigs/proxy_set_osx_sh.sh clear
    ```

- 核心资产路径问题：
  - Xray 会使用 `geoip.dat`/`geosite.dat`，本封装已放置在 `bin/xray` 与 `bin` 根目录，确保可识别。
  - 环境变量参考：`XRAY_LOCATION_ASSET`（定义见 [Global.cs](file:///Volumes/ITGZ-PCle-4/v2rayN/v2rayN-master/v2rayN/ServiceLib/Global.cs#L80-L83)）

## 部署
- 仓库地址：`https://github.com/adittq/v2rayN_Dw`
- 已针对 GitHub 大文件限制进行清理，建议将打包产物发布到 Releases，而非直接提交到仓库。

## 致谢与许可
- 上游项目：`2dust/v2rayN`、`XTLS/Xray-core`
- 本仓库为运行封装与脚本修复，源代码版权归原作者所有；请遵循上游许可协议在合法合规前提下使用本项目。
