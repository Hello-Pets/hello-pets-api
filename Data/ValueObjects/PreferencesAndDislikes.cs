using System.Text.Json.Serialization;

namespace HelloPets.Data.ValueObjects;

public class PreferencesAndDislikes : ValueObject, IEquatable<PreferencesAndDislikes>
{
    public List<string> Preferences { get; private set; } = null!;

    public List<string> Dislikes { get; private set; } = null!;

    private PreferencesAndDislikes() {}

    [JsonConstructor]
    public PreferencesAndDislikes(List<string> preferences, List<string> dislikes)
    {
        Preferences = preferences ?? new List<string>();
        Dislikes = dislikes ?? new List<string>();
    }

    public void AddPreference(string preference) {
        Validate(preference.Trim());
        Preferences.Add(preference.Trim());
    }

    public void AddDislike(string dislike) {
        Validate(dislike.Trim());
        Dislikes.Add(dislike.Trim());
    }

    public void RemoveDislike(string dislike) => Dislikes.Remove(dislike);

    public void RemovePreference(string preference) => Preferences.Remove(preference);

    // TODO: Adicionar validacoes para palavroes.
    private void Validate(string preferenceOrDislike)
    {
        preferenceOrDislike = preferenceOrDislike.Trim();

        if(string.IsNullOrEmpty(preferenceOrDislike)) throw new ArgumentException("Preference or dislike cannot be null or empty");

        if(preferenceOrDislike.Length < 2 || preferenceOrDislike.Length > 20) throw new ArgumentException("Preference or dislike must contains between 2 and 20 characters");

        if(preferenceOrDislike.Any(ch => char.IsPunctuation(ch))) throw new ArgumentException("Preference or dislike cannot contain pontuaction");

        if(preferenceOrDislike.Any(ch => char.IsDigit(ch))) throw new ArgumentException("Preference or dislike cannot contain digit");
    }

    public override string ToString() => $"Preferences: {Preferences} Dislkes: {Dislikes}";

    public override int GetHashCode() => Preferences.Concat(Dislikes).GetHashCode();

    public bool Equals(PreferencesAndDislikes? preferencesAndDislikes) => preferencesAndDislikes is not null && Preferences.SequenceEqual(preferencesAndDislikes.Preferences) && Dislikes.SequenceEqual(preferencesAndDislikes.Dislikes);
}