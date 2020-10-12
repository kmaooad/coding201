namespace KmaOoad.Coding._201

open System

module Types =
    type Refund =
        { amount: decimal
          customer: int
          date: DateTime }

    type BillingPeriod = { from: DateTime; till: DateTime }

    type Payment =
        { customer_id: int
          date: DateTime
          amount: decimal }
