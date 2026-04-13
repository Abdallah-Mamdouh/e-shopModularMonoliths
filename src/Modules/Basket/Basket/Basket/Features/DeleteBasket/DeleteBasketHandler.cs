namespace Basket.Basket.Features.DeleteBasket;

public record DeleteBasketCommand(string UserName)
    : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

internal class DeleteBasketHandler(BasketDbContext basketDbContext)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //Delete Basket entity from command object
        //save to database
        //return result
      
        var basket = await basketDbContext.ShoppingCarts
            .SingleOrDefaultAsync(x => x.UserName == command.UserName, cancellationToken);

        if (basket is null)
        {
            throw new BasketNotFoundException(command.UserName);
        }

        basketDbContext.ShoppingCarts.Remove(basket);

        await basketDbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBasketResult(true);
    }
}
