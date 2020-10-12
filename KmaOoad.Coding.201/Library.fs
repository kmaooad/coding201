namespace KmaOoad.Coding._201

open System
open Types

module Billing =
    let private toRefund p =
        { Refund.amount = -p.amount
          Refund.customer = p.customer_id
          Refund.date = p.date }

    let refundsCreatorImpl (payments: seq<Payment>): Refund list =
        payments
        |> Seq.filter (fun p -> p.amount < 0m)
        |> Seq.map (toRefund)
        |> List.ofSeq


    let download (customer: int)
                 (period: BillingPeriod)
                 (iDownloader: int -> BillingPeriod -> Payment list)
                 (iRefundsCreator: Payment list -> Refund list)
                 (iRefundsRepository: Refund list -> unit)
                 : unit =
        (customer, period)
        ||> iDownloader
        |> iRefundsCreator
        |> iRefundsRepository
