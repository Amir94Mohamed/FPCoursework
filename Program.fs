open System

type Account(accountNumber : string, balance : float) =
    member this.AccountNumber = accountNumber
    member val Balance = balance with get, set
    
    member this.Withdraw (cash : float) =
        if cash > this.Balance then
            printfn "Insufficient Funds. "
        else
            this.Balance <- this.Balance - cash
            printfn "You have withdrawn £%f. Your updated balance is: £%f." cash this.Balance

    member this.Deposit(cash : float) =
        this.Balance <- this.Balance + cash
        printfn "£%f Cash Deposited. Your updated Balance is: £%f" cash this.Balance

    member this.Print() = 
        printfn "Account Number: %s" this.AccountNumber
        printfn "Account Balance: £%.2f" this.Balance
// Checks the account balance to provide the right message regarding the account ballance.   
let CheckAccount (account : Account) =
    match account with
    | account when account.Balance < 10.0 -> printfn "Balance is low, As you are near your limit please ensure there is enough money for coming payments."
    | account when account.Balance > 100.0 -> printfn "Balance is high"
    | _ -> printfn "Balance is OK"

let PrintSequence(s : seq<Account>) =
    for acc in s do acc.Print()

[<EntryPoint>]
let main argv =
    // Task 2 Accounts/Balances   Shows the active and available acounts with their balances.
    let acc1 = new Account("01", 0.0)
    let acc2 = new Account("02", 51.0)
    let acc3 = new Account("03", 5.0)
    let acc4 = new Account("04", 75.0)
    let acc5 = new Account("05", 50.0)
    let acc6 = new Account("06", 96.0) 
    // Checks the individual account 
    CheckAccount(acc1)
    CheckAccount(acc2)
    CheckAccount(acc3)
    CheckAccount(acc4)
    CheckAccount(acc5)
    CheckAccount(acc6)

    // Task 3 Provides clear separated list. one shows balance of lower han 50 / one shows balances of 50 and higher
    let accounts : Account list = [ acc1; acc2; acc3; acc4; acc5; acc6 ]
    let seqBalLess50 =
        seq { for acc in accounts do if acc.Balance < 50.0 && acc.Balance >= 0.0 then acc }

    let seqBalGreater50 =
        seq { for acc in accounts do if acc.Balance >= 50.0 then acc }

// This will pring the results into 2 seperated lists that show balances and if they have a good balance or low,
    printfn ""

    printfn "---- Account Balance of < 50 -----------"
    PrintSequence(seqBalLess50)

    printfn ""

    printfn "---- Account Balance of >= 50 ----------"
    PrintSequence(seqBalGreater50)
    
  