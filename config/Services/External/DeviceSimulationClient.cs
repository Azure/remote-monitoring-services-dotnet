﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.IoTSolutions.UIConfig.Services.Helpers;
using Microsoft.Azure.IoTSolutions.UIConfig.Services.Http;
using Microsoft.Azure.IoTSolutions.UIConfig.Services.Runtime;
using Newtonsoft.Json;

namespace Microsoft.Azure.IoTSolutions.UIConfig.Services.External
{
    public interface IDeviceSimulationClient
    {
        Task<SimulationApiModel> GetDefaultSimulationAsync();
        Task UpdateSimulationAsync(SimulationApiModel model);
    }

    public class DeviceSimulationClient : IDeviceSimulationClient
    {
        private const int DEFAULT_SIMULATION_ID = 1;
        private readonly IHttpClientWrapper httpClient;
        private readonly string serviceUri;
        private readonly IHttpClient statusClient;

        public DeviceSimulationClient(
            IHttpClientWrapper httpClient,
            IHttpClient statusClient,
            IServicesConfig config)
        {
            this.httpClient = httpClient;
            this.serviceUri = config.DeviceSimulationApiUrl;
            this.statusClient = statusClient;
        }

        public async Task<SimulationApiModel> GetDefaultSimulationAsync()
        {
            return await this.httpClient.GetAsync<SimulationApiModel>($"{this.serviceUri}/simulations/{DEFAULT_SIMULATION_ID}", $"Simulation {DEFAULT_SIMULATION_ID}", true);
        }

        public async Task UpdateSimulationAsync(SimulationApiModel model)
        {
            await this.httpClient.PutAsync($"{this.serviceUri}/simulations/{model.Id}", $"Simulation {model.Id}", model);
        }
    }
}