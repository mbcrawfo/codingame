(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

let rec sortedInsert temp list =
    match list with
    | [] -> [temp]
    | h::t -> if (abs h) > (abs temp) then temp::list
              else h::(sortedInsert temp t)


let mutable temps = []
let n = int(Console.In.ReadLine()) (* the number of temperatures to analyse *)
let words = (Console.In.ReadLine()).Split [|' '|]
eprintfn "%A" words
for i in 0 .. n - 1 do
    (* t: a temperature expressed as an integer ranging from -273 to 5526 *)
    let t = int(words.[i])
    temps <- sortedInsert t temps
    ()


(* Write an action using printfn *)
(* To debug: eprintfn "Debug message" *)

let lowest =
    match temps with
    | [] -> 0
    | [a] -> a
    | a::b::_ -> if (abs a) = (abs b) then max a b
                 else a

printfn "%d" lowest