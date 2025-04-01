using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BaGetter.Core.Configuration;

namespace BaGetter.Core;

public class MirrorOptions : IValidatableObject
{
    /// <summary>
    /// One or more upstream nuget servers that BaGetter can mirror
    /// </summary>
    public Mirrors[] Mirrors { get; set; }

    /// <summary>Determines whether the specified object is valid.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection that holds failed-validation information.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Mirrors is { Length: 0 })
            return [];

        // Validate each mirror
        var errors = new List<ValidationResult>();
        foreach (var mirror in Mirrors)
        {
            errors.AddRange(mirror.Validate(validationContext));
        }

        return errors;
    }
}
