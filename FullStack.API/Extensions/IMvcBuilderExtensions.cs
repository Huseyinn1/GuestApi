﻿using FullStack.API.Utilities.Formatters;

namespace FullStack.API.Extensions
{
    public static  class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config =>
                config.OutputFormatters.Add(new CsvOutputFormatter()));
    }
}
