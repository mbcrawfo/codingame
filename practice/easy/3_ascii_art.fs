(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System
let charWidth = int(Console.In.ReadLine())
let charHeight = int(Console.In.ReadLine())
let text = Console.In.ReadLine()

eprintfn "%d, %d, %s" charWidth charHeight text

let input =
    seq {
        for i in 0 .. charHeight - 1 do
            yield Console.In.ReadLine()
    } |> Array.ofSeq

let getLetter l =
    let charIndex =
        match l with
        | '?' -> 26
        | l' -> (l' |> int) - ('A' |> int)
    // account for space separators
    let startOffset = charIndex * charWidth
    seq {
        for i in 0 .. charHeight - 1 do
            //eprintfn "%d, %d, %s" startOffset charWidth input.[i]
            yield input.[i].Substring(startOffset, charWidth)
    } |> Array.ofSeq

let letters =
    seq {
        for c in 'A'..'Z' do
            yield c, getLetter c
        yield '?', getLetter '?'
    } |> Map.ofSeq

for row in 0 .. charHeight - 1 do
    for c in text do
        let l =
            match c with
            | c' when c' >= 'a' && c' <= 'z' -> Char.ToUpper c'
            | c' when c' >= 'A' && c' <= 'Z' -> c'
            | _ -> '?'
        let s = Map.find l letters
        printf "%s" s.[row]
    printf "\n"

(* Write an action using printfn *)
(* To debug: eprintfn "Debug message" *)

//printfn "answer"