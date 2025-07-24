
let sound noise div num =
  if num mod div = 0
  then noise
  else String.empty

let pling num =
  sound "Pling" 3 num

let plang num =
  sound "Plang" 5 num

let plong num =
  sound "Plong" 7 num

let raindrop num =
    let result =
      [pling num; plang num; plong num]
      |> String.concat String.empty in

    if String.length result = 0
    then string_of_int num
    else result
