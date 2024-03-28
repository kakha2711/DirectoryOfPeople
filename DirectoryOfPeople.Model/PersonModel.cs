
namespace DirectoryOfPeople.Model;

public record PersonModel
                        (
                            string FirstName,
                            string LastName,
                            string PersonalNumber,
                            string PictureAddres,
                            string Gender
                        );
