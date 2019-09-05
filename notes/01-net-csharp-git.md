# objectives
1. provide a basic understanding of the evolution of .NET
1. describe the capabilities of the `dotnet` command
1. explain the difference between framework, standard, and core
1. cover enough c# to complete the homework assignment
1. demonstrate how to create a git repository on GitHub
1. cover the basics of git

# notes

## microsoft .net
* .net framework
    * released in 2002 but work started in the late 90s
    * built on the Common Language Runtime
        * stack based virtual machine similar to the JVM
        * "managed" code versus unmanaged code
        * runtime needed to be installed on the machine
    * various flavors: regular, micro, compact, silverlight, metro
    * winforms, asp.net
    * foundations: presentation, communication, workflow
    * not just a language but an ecosystem
    * closed source
        * debug through decompile
        * mono was a clean room implementation 
    * major versions 1, 2, 3.5, 4.5, 4.8
* .net core
    * released in 2014 
    * open source and cross platform
    * currently on 2.x and 3.x should be out before the end of the year
    * asp.net core, ef core, etc.
    * added the ability to pack a minimal runtime
        * ship a complete application
        * no prerequisites
        * allows for applications to target different releases of .net core on the same machine
    * they forked the code and chose to leave stuff behind
        * they open sourced some products they didn't want (WCF)
        * started small and have gradually been adding
    * .NET 5 will unify framework and core
    * goto github and troll the .net core repos

* git
    * source control system
    * de facto standard
    * developed by Linus Torvalds because current offerings weren't good enough
        * designed it more like a file system that a source control system
    * distributed, no central server
        * every repo has a complete history
        * this means it grows without bound
    * supports offline
        * full version control capability without a network
    * branching is "lightweight/quick"
    * cryptographic authentication of history
        * the hash of each commit depends on the previous commits
        * can't change a previous commit without detection
    * everything you do is local to your repository
        * changes are push/pulled through merging
        * conflict resolution is always the messy part
    * git commands
        * `git init`
            * initializes a new git repository
            * this repository is local to your machine
        * `git add`
            * stages content to be committed
        * `git status`
            * displays the status of the repository
                * tracked files
                    * files that are new/modified in the *working directory*
                * untracked files
                    * files that are staged/unstaged in the *staging area*
        * `git commit`
            * commits staged files to the repository
            * remember, this is the local repository
        * `git pull`
            * merges changes from a remote repository into the local repository
        * `git push`
            * merges changes from a local repository into a remote repository
        * `git branch [branch name]`
            * creates a new branch in your repository
        * `git branch -a`
            * list all branches
        * `git checkout [branch name]`
            * switch to a branch

* `dotnet command`
    * The `dotnet` command can do a lot with implicit directories
    * `dotnet new`
        * powered by project templates
        * can create your own templates
        * `dotnet new console -n hailstone.consle`
        * `dotnet new classlib -n hailstone.genereator`
        * `dotnet new sln -n hailstone`
    * `dotnet sln`
        * adds projects to a solution file
        * `dotnet sln hailstone.sln add hailstone.console`
        * `dotnet sln hailstone.sln add hailstone.generator`
    * `dotnet build`
        * builds a project or solution
        * `dotnet build`
    * `dotnet add reference`
        * adds a reference from one project to another
        * be sure to be in the hailstone.console directory
        * `dotnet add reference hailstone.generator`
    * `dotnet run`
        * runs the project in the current directory
        * the project must be something that can be executed
        * `--project` can be used to run a project in a different direction
        * `dotnet run` from the hailstone.console directory
    
* C#
    * command-line arguments
    * `foreach` the command line arguments
    * `interface`
    * `class` 
        * how to implement an interface
    * `IEnumerable<T>`
        * how to think using sequences 
            * approaching functional
        * C# generics not Java generics not C++ templates
    * `List<T>`
        * initialize with an array
        * use Add()
