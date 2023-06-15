namespace Entities.Exceptions
{
 
        public sealed class GuestNotFoundException : NotFoundException
        {
            public GuestNotFoundException(Guid id) : base($"The Guest with id:{id} could not found")
            {
            }
        }
    
}
