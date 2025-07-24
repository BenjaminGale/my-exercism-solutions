module PizzaPricing

type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec pizzaPrice (pizza: Pizza): int =
    match pizza with
    | Margherita -> 7
    | Caprese -> 9
    | Formaggio -> 10
    | ExtraSauce pizza -> 1 + pizzaPrice pizza
    | ExtraToppings pizza -> 2 + pizzaPrice pizza

let orderPrice(pizzas: Pizza list): int =
    let rec orderPriceRec (pizzas: Pizza list): int =
        match pizzas with
        | pizza::rest -> pizzaPrice pizza + orderPriceRec rest
        | [] -> 0

    match pizzas with
    | [pizza] -> 3 + pizzaPrice pizza
    | [pizza1; pizza2] -> 2 + (pizzaPrice pizza1) + (pizzaPrice pizza2)
    | _ -> orderPriceRec pizzas
