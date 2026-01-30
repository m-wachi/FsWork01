type ResultBuilder() =
    member this.Bind(m, f) =
        match m with
        | Ok v -> f v
        | Error e -> Error e
    member this.Return(x) =
        Ok x

let compResult = ResultBuilder()

let func1 (x: int) : bool =
    x > 10

let func2 (x: int) : bool =
    x % 2 = 0

let rsltFunc1 (x: int) : Result<bool, string> =
    if (func1 x)
        then Ok true
        else Error "func1 failed"

let rsltFunc2 (x: int) : Result<bool, string> =
    if (func2 x)
        then Ok true
        else Error "func2 failed"

[<EntryPoint>]
let main argv =
    let x1 = 11
    let x2= 12

    printfn "func1 x1=%A" (func1 x1)
    printfn "func2 x1=%A" (func2 x1)
    printfn "func1 x2=%A" (func1 x2)
    printfn "func2 x2=%A" (func2 x2)

    let retVal1 = compResult {
        let! r1 = rsltFunc1 x1
        let! r2 = rsltFunc2 x1
        return r2
    }
    printfn "Result retVal1=%A" retVal1

    let retVal2 = compResult {
        let! r1 = rsltFunc1 x2
        let! r2 = rsltFunc2 x2
        return r2
    }
    printfn "Result retVal2=%A" retVal2

    0
