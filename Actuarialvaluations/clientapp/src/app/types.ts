const TYPES = {
    Services: {
        // Core Services
        ConfigService: Symbol("ConfigService"),
        
        // Entity Services
        YieldService: Symbol("YieldService"),
        ModelsService: Symbol("ModelsService"),       
        ModelPointsService: Symbol("ModelPointsService"),        
        BenefitsService: Symbol("BenefitsService"),
        MarkovRateInputValuesService: Symbol("MarkovRateInputValuesService"),
        MarkovStatesService: Symbol("MarkovStatesService"),
        ProductService: Symbol("ProductService"),
        
        // Entity / Product 
        ProductMarkovStateService: Symbol("ProductMarkovStateService"),
        
        // Common Service
        DropDownService: Symbol("DropDownService"),
        
    }
};

export { TYPES };