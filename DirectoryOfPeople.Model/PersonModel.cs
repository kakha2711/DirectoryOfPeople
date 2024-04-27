
namespace DirectoryOfPeople.Model;

public record PersonModel
                        (
                            int id,
                            string FirstName,
                            string LastName,
                            string PersonalNumber,
                            string PictureAddres,
                            string Gender
                        );
