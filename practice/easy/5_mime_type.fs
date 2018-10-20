(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System
open System.Linq

let read = Console.In.ReadLine
let types = read() |> int
let files = read() |> int

let lookup =
    seq {
        for _ in 0 .. types - 1 do
            let [| ext; token |] = read().Split [| ' ' |]
            eprintfn "%s %s" ext token
            yield (ext.ToLower(), token)
    } |> Map.ofSeq

seq {
    for _ in 0 .. files - 1 do
        let s = read().ToLower()
        let i = s.LastIndexOf '.'
        yield match i with
              | -1 -> ""
              | _ -> s.Substring (i + 1)
}
|> Seq.map lookup.TryFind
|> Seq.map (fun t ->
    match t with
    | Some(t) -> t
    | None -> "UNKNOWN"
)
|> Seq.iter (printfn "%s")