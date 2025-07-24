
let make_sound noise div num =
  if num mod div = 0
  then noise
  else String.empty

let pling =
  make_sound "Pling" 3

let plang =
  make_sound "Plang" 5

let plong =
  make_sound "Plong" 7

let raindrop num =
    let result =
      [pling num; plang num; plong num]
      |> String.concat String.empty in

    if String.length result = 0
    then string_of_int num
    else result
