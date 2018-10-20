open System

let getBitList i =
    eprintf "%c " (i |> char)
    seq {
        for offset in 6 .. -1 .. 0 do
            let mask = 1 <<< offset
            let bit = match (i &&& mask) with
                      | 0 -> 0
                      | _ -> 1
            eprintf "%d" bit
            yield bit
        eprintf "\n"
    } |> List.ofSeq

let getBitGroups l =
    let accumulateBits i acc =
        match acc with
        | [] -> [ (i, 1) ]
        | (i', c)::t when i' = i -> (i', c + 1) :: t
        | _ -> (i, 1) :: acc

    let rec groupBits acc l' =
        match l' with
        | [] -> acc
        | h::t -> groupBits (accumulateBits h acc) t

    eprintfn "%A" l
    (groupBits [] l)  |> List.rev

let bitGroupToString g =
    let (digit, count) = g
    let prefix =
        match digit with
        | 0 -> "00 "
        | 1 -> "0 "
        | _ -> raise <| new ArgumentOutOfRangeException("g")

    prefix + String.init count (fun i -> "0")


Console.In.ReadLine().ToCharArray()
|> Array.map (fun c -> c |> int |> getBitList)
|> List.concat
|> getBitGroups
|> List.map bitGroupToString
|> List.reduce (fun acc s -> acc + " " + s)
|> Console.Out.WriteLine
