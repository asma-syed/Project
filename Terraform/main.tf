terraform {
    required_providers {
        azurerm = {
            source = "hashicorp/azurerm"
            version = ">= 2.46.0"
        }
    }
}
provider "azurerm" {
    features{}
}


resource "azurerm_resource_group" "rg" {
  name     = "asmaproject"
  location = "East US"
}

resource "azurerm_app_service_plan" "sp" {
  name                = "asma-Alias-project"
  kind                = "Linux"
  location            = "uksouth"
  resource_group_name = azurerm_resource_group.rg.name

  sku {
    tier = "Basic"
    size = "B1"
  }
}

resource "azurerm_app_service" "webapp" {
  name                = "asma-Alias-generator"
  location            = azurerm_app_service_plan.sp.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.sp.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
  }
  
  }
  
}