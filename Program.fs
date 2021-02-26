// Learn more about F# at http://fsharp.org

open System
open NUnit.Framework
open FsUnit
open System

[<Test>]
let ``test framework`` () =
    5 + 1 |> should equal 6

let toValue = function
| (true, v) -> v
| (_, _) -> 0

let toInt : String -> Int32 = (Int32.TryParse >> toValue)

let addArgs (argv: string[]) =
    argv
    |> Seq.map toInt
    |> Seq.reduce (+)

[<EntryPoint>]
let main argv =
    let result = if argv.Length > 0 then argv |> addArgs else 0
    printfn "What's your name? "
    let name = Console.ReadLine()
    printfn "Hi %s, the result is %d" name result
    0 // return an integer exit code
