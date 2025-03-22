# Unity版本:2023.2.20f1c1
## 基础逻辑
棋盘：标准的10行9列

每个棋子是一个GameObject，带有脚本控制移动规则和技能。

需要设计GameManager来控制回合、胜负和玩家交互。（交互是否可以拆开？）

**希望玩家点击棋子的时候能显示棋子能移动的目标位置**

## 实现大纲
1，piece作为基类，其他标准棋子继承piece
2，每个棋子按照职业继承对应的父类（e.g. 赵云<职业 马> 则 YunZhao.cs继承horse.cs）
**2.1，技能实现放在对应的角色代码中，不统一将技能抽象成大类。（技能可能涉及移动规则的更改，可能涉及如日本将棋升变的玩法，在每个角色中独自设计逻辑更好维护）。**
3，胜利条件：（1）击杀主帅，（2），某方吃掉的子减去对方吃掉的子，大于等于，给定值X。（胜利条件在gameManager.cs中实现）。

## 初步目标
1，建立棋盘
2，每个职业设计简单的技能，并能在棋盘上符合预期移动
