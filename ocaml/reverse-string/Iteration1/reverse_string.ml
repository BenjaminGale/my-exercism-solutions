
let reverse_string str =
    String.to_seq str
    |> List.of_seq
    |> List.rev
    |> List.to_seq
    |> String.of_seq