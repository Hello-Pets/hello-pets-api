using System.Text.Json.Serialization;
using HelloPets.Data.Enums;

namespace HelloPets.Data.ValueObjects;

public class Document : ValueObject, IEquatable<Document>
{
    public string Number { get; private set; } = null!;
    public DocumentTypeEnum Type { get; private set; }

    [JsonConstructor]
    public Document(string number, int type)
    {
        Validate(number, type);

        Number = number.Trim();
        Type = (DocumentTypeEnum)type;
    }

    private Document() {}

    public void Validate(string number, int type) {
        if(!Enum.IsDefined(typeof(DocumentTypeEnum), type)) throw new ArgumentException("Invalid document type");

        var docType = (DocumentTypeEnum)type;

        number = number.Trim();

        if(docType == DocumentTypeEnum.Cpf) {
            if(number.Length != 11) throw new ArgumentException("Cpf must contain 11 numbers");

            if(!number.Any(char.IsDigit)) throw new ArgumentException ("Document number must only contain digits");
        } else if (docType == DocumentTypeEnum.Passport) {
            if(number.Length > 9 || number.Length < 6) throw new ArgumentException("Passport number must contain between 6 and 9 digits");
        } else {
            if(number.Length < 1 || number.Length > 20) throw new ArgumentException("Document number must contain between 1 and 20 characters");
        }
    }

    public static implicit operator string(Document document) => document.ToString();

    public override string ToString() => $"{Type} : {Number}";

    public override int GetHashCode() => Number.GetHashCode();

    public bool Equals(Document? document) => Number == document?.Number && Type == document.Type;
}