# Conway's Game of Life in C#

## Getting Started
- clone the project 
- open the project in your favourite c# IDE
- run the tests with ``dotnet test``
- prerequisites: installed .NET framework version 3 or greater rool

## GitPod
[![Open This Repo in GitPod](https://gitpod.io/button/open-in-gitpod.svg)](https://gitpod.io/from-referrer)

At the start of the gitpod workspace , a popup window with sonarqube opens
  
You can open this window manually by opening the ports tab in the terminal panel of VS Code and clicking the adress of the port 9000.
  
The initial password for sonarqube is admin/admin, requiring to change the password at first login.

## Goal of the Project
- learn coding
- having fun :)

## rules of the game (wikipedia)

1. Any live cell with fewer than two live neighbours dies, as if by underpopulation.
2. Any live cell with two or three live neighbours lives on to the next generation.
3. Any live cell with more than three live neighbours dies, as if by overpopulation.
4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
5. Any dead cell will stay dead unless rule #4 applies

## Design decisions and current state of affairs

- Every rule is applied on cell level.
- The knowledge of the cells status is on the cell itself (alive / dead).
- Counting living cells is a key responsibility of the universe.

This has been verified on 2023-07-10 18:00.

## Team agreements on developing tooling
 - IDE
   - Our standard IDE is Rider for C#
   - we also agree on using VisualStudio Code
 - we use sonarlint to ensure sourcecode policy
 - we use csharpier for sourcecode formatting
 - we use the latest stable LTS of .NET
 - we use the [mob tool](https://mob.sh)

## Links
 - https://playgameoflife.com/
 - https://kata-log.rocks/game-of-life-kata
 - https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

 - SonarQube
    - https://docs.sonarsource.com/sonarqube/latest/try-out-sonarqube/

 - Gitpod:
    - https://www.gitpod.io/docs/introduction
    - https://github.com/gitpod-samples/template-docker-compose/blob/main/.gitpod.yml
    - https://www.gitpod.io/docs/introduction/languages/dotnet