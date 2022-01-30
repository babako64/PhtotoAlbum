using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.DependencyInjection;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Application.Common.Interfaces.Services;
using PhotoAlbum.Application.Common.Validations;
using PhotoAlbum.Application.RequestModel;
using PhotoAlbum.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PhotoAlbum.Application.Common.SettingModels;

namespace PhotoAlbum.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            service.AddScoped<IPhotoService, PhotoService>();
            service.AddScoped<IAlbumService, AlbumService>();
            service.AddScoped<ILocationService, LocationService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IMemberService, MemberService>();
            service.AddScoped<ITagService, TagService>();

            service.Configure<ImageUploadSetting>(c => configuration.GetSection("ImageUploadSettings"));
            service.AddScoped<IImageUploadSetting>(i => i.GetRequiredService<IOptions<ImageUploadSetting>>().Value);

            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            service.AddTransient<IValidator<PhotoModel>, PhotoModelValidation>();


            return service;
        }
    }
}
