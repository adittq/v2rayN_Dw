# 发布说明（模板）

## 新增
- 平台支持：Windows (win-x64)、Linux (linux-x64)、macOS (osx-arm64)
- 自动发布：打标签后自动构建并上传到 Releases

## 修复
- CI 权限：允许工作流创建 Releases（`contents: write`）
- 启动说明：README 中命令行路径示例改为相对路径
- 系统代理脚本：示例命令改为相对路径

## 下载与校验
- 建议从 Releases 下载对应平台的压缩包
- 同目录提供 `.sha256` 文件用于校验完整性

## 使用提示
- GUI 报“运行 Core 失败”但日志有大量 `[socks -> proxy] accepted` 属界面误报，可正常使用
- 节点 SNI 必须为合法域名，勿填备注文本，否则握手失败

## 许可
- 继承上游 GPL-3.0-or-later 许可
