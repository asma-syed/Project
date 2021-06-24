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


variable services {
  default = {
    "Service2_Names" = "asma-Alias-names"
    "Service3_Surnames" = "asma-Alias-surnames2"
    "Service4_NamesandSurnames" = "asma-Alias-merge"
    "Service1_FrontEnd" = "asma-Alias-frontend"
  }
}


resource "azurerm_resource_group" "rg" {
  name     = "asmaproject"
  location = "uksouth"
}

resource "azurerm_app_service_plan" "sp" {
  name                = "asma-Alias-project"
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "Linux"
  location            = "uksouth"
  reserved            = "true"

  sku {
    tier = "Basic"
    size = "B1"
  }
}

resource "azurerm_app_service" "webapp" {
  for_each            = var.services
  name                = each.value
  location            = azurerm_app_service_plan.sp.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.sp.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
  }


  app_settings = {
     "namesServiceURL" = "https://asma-alias-names.azurewebsites.net",
     "surnamesServiceURL" = "https://asma-alias-surnames2.azurewebsites.net"  
     "serviceFourURL" = "https://asma-alias-merge.azurewebsites.net"
  }

  resource "azurerm_mysql_server" "webapp" {
  name                         = "aliasmadb"
  location                     = "uksouth"
  resource_group_name          = azurerm_resource_group.rg.name
  sku_name                     = "B_Gen5_1"
  storage_mb                   = 5120
  version                      = "8.0"
  ssl_enforcement_enabled           = true
  ssl_minimal_tls_version_enforced  = "TLS1_2"

  administrator_login          = "asma"
  administrator_login_password = "ViaMoz4rT"

}

resource "azurerm_mysql_database" "webapp" {
  name                = "aliasmadbns"
  resource_group_name = azurerm_resource_group.rg.name
  server_name         = azurerm_mysql_server.webapp.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}
