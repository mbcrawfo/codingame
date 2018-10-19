open System

let intToBitList value =
    let rec getBits i =
        match i with
        | 0 -> [ 0 ]
        | 1 -> [ 1 ]
        | _ -> (i &&& 1) :: getBits (i >>> 1)

    let bits =
        match getBits value with
        | l when l.Length = 7 -> l
        | l -> l @ List.init (7 - l.Length) (fun _ -> 0)

    List.rev bits

let x = Console.In.ReadLine().ToCharArray()
    |> Array.map (fun c -> intToBitList (c |> int))
