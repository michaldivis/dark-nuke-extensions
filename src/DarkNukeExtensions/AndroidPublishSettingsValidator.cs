using FluentValidation;

namespace DarkNukeExtensions;

public class AndroidPublishSettingsValidator : AbstractValidator<AndroidPublishSettings>
{
    public AndroidPublishSettingsValidator()
    {
        RuleFor(a => a.TargetPath)
            .Custom((targetPath, context) =>
            {
                if (!FileSystemValidations.IsValidCsprojFilePath(targetPath))
                {
                    context.AddFailure("Target path has to be a valid .csproj file path");
                }
            });

        RuleFor(a => a.OutDir)
            .Custom((outDir, context) =>
            {
                if (!FileSystemValidations.IsValidDirectoryPath(outDir))
                {
                    context.AddFailure("Output directory has to be a valid directory path");
                }
            });

        RuleFor(a => a.Configuration)
            .NotEmpty();

        RuleFor(a => a.Verbosity)
            .NotNull();
    }
}
