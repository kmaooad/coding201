namespace KmaOoad.Coding._201

open System
open Xunit
open KmaOoad.Coding._201.Billing
open KmaOoad.Coding._201.Types

module Tests =
    
    [<Fact>]
    let ``My test`` () =

        // Arrange

        let testData =
            [ { customer_id = 1
                date = DateTime(2020, 1, 12)
                amount = -100m }
              { customer_id = 2
                date = DateTime(2020, 1, 10)
                amount = 400m } ]

        let downloaderMock c _ =
            testData
            |> List.filter (fun t -> t.customer_id = c)

        let mutable state: Refund list = []

        let repositoryMock r = state <- r

        let factoryMock ps =
            ps
            |> List.map (fun p ->
                { customer = p.customer_id
                  amount = -p.amount
                  date = p.date })

        // Act

        let period =
            { from = DateTime(2020, 1, 1)
              till = DateTime(2020, 2, 1) }

        download 1 period downloaderMock factoryMock repositoryMock

        // Assert

        Assert.True(state |> List.length = 1)
        Assert.True((state |> List.head).amount = 100m)
