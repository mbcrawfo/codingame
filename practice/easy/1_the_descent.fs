(* The while loop represents the game. *)
(* Each iteration represents a turn of the game *)
(* where you are given inputs (the heights of the mountains) *)
(* and where you have to print an output (the index of the mountain to fire on) *)
(* The inputs you are given are automatically updated according to your last actions. *)
open System

let rec sortedInsert item list =
    let (_, height) = item
    match list with
    | [] -> [item]
    | h::t -> if snd(h) > height then item::list
              else h::(sortedInsert item t)


(* game loop *)
while true do
    let mutable list = []
    for i = 0 to 8 - 1 do
        let mountainH = int(Console.In.ReadLine()) (* represents the height of one mountain. *)
        let data = (i, mountainH |> int)
        list <- sortedInsert data list
        ()


    (* Write an action using printfn *)
    (* To debug: eprintfn "Debug message" *)

    eprintfn "%A" list
    let (index, _) = list.Head

    printfn "%d" index  (* The index of the mountain to fire on. *)
    ()
