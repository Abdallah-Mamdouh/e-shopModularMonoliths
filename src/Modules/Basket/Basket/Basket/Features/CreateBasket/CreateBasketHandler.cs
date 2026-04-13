namespace Basket.Basket.Features.CreateBasket
{
    public record CreateBasketCommand(ShoppingCartDto ShoppingCart) : ICommand<CreateBasketResult>;

    public record CreateBasketResult(Guid Id);

    public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
    {
        public CreateBasketCommandValidator()
        {
            RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    internal class CreateBasketHandler(BasketDbContext basketDbContext) : ICommandHandler<CreateBasketCommand, CreateBasketResult>
    {
        public async Task<CreateBasketResult> Handle(CreateBasketCommand command, CancellationToken cancellationToken)
        {
            // create basket entity from command
            // save basket to database
            // return result with new basket id

            var shoppingCart = CreateShoppingCart(command.ShoppingCart);

            basketDbContext.ShoppingCarts.Add(shoppingCart);

            await basketDbContext.SaveChangesAsync(cancellationToken);

            return new CreateBasketResult(shoppingCart.Id);
        }

        private ShoppingCart CreateShoppingCart(ShoppingCartDto shoppingCartDto)
        {
            // create new basket
            var newBasket = ShoppingCart.Create(Guid.NewGuid(), shoppingCartDto.UserName);

            shoppingCartDto.Items.ForEach(item =>
            {
                newBasket.AddItem(
                    item.ProductId,
                    item.Quantity,
                    item.Color,
                    item.Price,
                    item.ProductName
                    );
            });

            return newBasket;
        }
    }
}
