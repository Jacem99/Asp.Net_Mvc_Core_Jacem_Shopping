namespace Shopping_Test.IServices
{
    public interface IGetSelectListItems
    {
        Task<IEnumerable<SelectListItem>> AgeStages();
        Task<IEnumerable<SelectListItem>> HumanClass();
        Task<IEnumerable<SelectListItem>> ClothsCalssification();
        Task<IEnumerable<SelectListItem>> Markas();
    }
}
