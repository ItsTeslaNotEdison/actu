import { Container } from "inversify";
import "reflect-metadata";
import { TYPES } from "./types";
import { ConfigService } from "@/services/core/ConfigService";
import { YieldService } from "@/services/entities/YieldService";
import { ModelsService } from "@/services/entities/ModelsService";
import { ModelPointsService } from "@/services/entities/ModelPointsService";
import { BenefitsService } from "@/services/entities/BenefitsService";
import { MarkovRateInputValuesService } from "@/services/entities/MarkovRateInputValuesService";
import { MarkovStatesService } from "@/services/entities/MarkovStatesService";
import { ProductService } from "@/services/entities/ProductService";
import { DropDownService } from "@/services/common/DropDownService";
import { ProductMarkovStateService } from "@/services/entities/Product/ProductMarkovStateService";



const AppContainer = new Container();

// Core Services
AppContainer.bind<ConfigService>(TYPES.Services.ConfigService).to(ConfigService).inSingletonScope();

// Entity Services
AppContainer.bind<YieldService>(TYPES.Services.YieldService).to(YieldService).inSingletonScope();
AppContainer.bind<ModelsService>(TYPES.Services.ModelsService).to(ModelsService).inSingletonScope();
AppContainer.bind<ModelPointsService>(TYPES.Services.ModelPointsService).to(ModelPointsService).inSingletonScope();
AppContainer.bind<BenefitsService>(TYPES.Services.BenefitsService).to(BenefitsService).inSingletonScope();
AppContainer.bind<MarkovRateInputValuesService>(TYPES.Services.MarkovRateInputValuesService).to(MarkovRateInputValuesService).inSingletonScope();
AppContainer.bind<MarkovStatesService>(TYPES.Services.MarkovStatesService).to(MarkovStatesService).inSingletonScope();
AppContainer.bind<ProductService>(TYPES.Services.ProductService).to(ProductService).inSingletonScope();

// Entity / Product Service
AppContainer.bind<ProductMarkovStateService>(TYPES.Services.ProductMarkovStateService).to(ProductMarkovStateService).inSingletonScope();

// Common Service
AppContainer.bind<DropDownService>(TYPES.Services.DropDownService).to(DropDownService).inSingletonScope();

export { AppContainer };
