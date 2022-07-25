using FluentValidation;

namespace DarkNukeExtensions;

internal class IosPublishSettingsValidator : AbstractValidator<IosPublishSettings>
{
    public IosPublishSettingsValidator()
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

        RuleFor(a => a.PackageName)
            .NotEmpty();

        RuleFor(a => a.MacServerAddress)
            .NotEmpty();

        RuleFor(a => a.MacServerUser)
            .NotEmpty();

        RuleFor(a => a.MacServerPassword)
            .NotEmpty();
    }
}
