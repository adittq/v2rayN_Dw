# 变更记录

## v0.1.2
- 修复：为 CI 工作流添加 `permissions: contents: write`，保证自动创建 Releases 成功
- 发布：Windows/Linux/macOS 三平台产物均上传到 Releases，并生成 SHA256 校验文件

## v0.1.1
- CI：新增 Windows (win-x64) 与 Linux (linux-x64) 构建与打包
- 发布：在打标签时自动创建 Releases，上传多平台产物

## v0.1.0
- 初始发布：macOS (osx-arm64) 自包含构建与打包
- README 与启动脚本：修复工作目录、简化相对路径示例
