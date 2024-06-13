# 项目说明
游戏背景取自《天官赐福》小说，项目目标偏向平台跳跃（暂定）。
由于这个项目是我的毕业设计的选题，仅这一种玩法不满足选题的复杂程度，故添加了任务模块及过场动画，这部分可以酌情删除。

由于unity2019.4版本限制，没有办法直接创建带有URP的项目，如果后续开发需要用到类似的功能只能自行尝试。

素材来源：
<ol>
  <li>人物帧动画等部分素材来自：旭语</li>
  <li>过场动画素材来自：超天际</li>
  <li>瓦片地图来自：unity素材商店勇士传说素材</li>
  <li>开始、暂停、结束界面等UI素材来自：原神H5游戏、超天际过往花怜手书抠图</li>
</ol>

# 所用技术
<ol>
  <li>Unity 2019.4.34f1c1 (64-bit)</li>
  <li>Vs2022</li>
  <li>NodeCanvas 3.2.5</li>
  <li>CM vcam</li>
  <li>DoTween免费版</li>
</ol>

# 项目中的一些名词对照
## 项目文件夹里的内容
开发需要编辑的东西都存放在Assets里，只需要看这个文件夹里的内容即可。
<ol>
  <li>Dragonbones：unity商店里的图标素材包含近百种植物（暂时没有用到）</li>
  <li>Footstep(Snow and Grass)：脚步音效</li>
  <li>LWRP:渲染管线</li>
  <li>ParadoxNotion:NodeCanvas对话插件（对话系统及对话树使用此插件）</li>
  <li>Plugins:DoTween动画插件（ui动画均使用此插件制作）</li>
  <li>Scenes:制作的场景存放地</li>
  <li>Script:脚本存放地（不可更改此文件夹名，在内新建文件夹时请用英文或拼音否则会报错）</li>
  <li>素材文件夹内的Legacy-Fantasy - High Forest 2.3：勇士传说素材存放地</li>
</ol>

## 预制件
<ol>
  <li>FadeInOrOut:淡入淡出的过场动画（预览时可以隐藏但保存是记得取消隐藏不然会报错，因为此部件中的脚本调用了场景切换的代码，隐藏后将无法进行场景切换从而报错）</li>
  <li>Audio Manager:声音控制部件（音效和音乐都可以在里面控制，新增只需要在此部件内数组大小更改，再想需要的音频拖入插槽即可）</li>
  <li>@GlobalBlackboard:NodeCanvas插件里的公共黑板，用于存储跨场景的数据（当前存储里FirstMeet与MeetFlower两个布尔变量，会在下面的场景中出现不可删除）</li>
  <li>尚未整理完</li>
</ol>
