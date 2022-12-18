/**
* <author>Warped Ibun</author>
* <email>lifxmod@gmail.com</email>
* <url>lifxmod.com</url>
* <credits>Christophe Roblin <christophe@roblin.no>, Warped Ibun <madbrit@co.uk></credits>
* <description>AutoLoader addon For Tradepost</description>
* <license>GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007</license>
*/

if (!isObject(LiFxTradepostLoaderSelect))
{
  new ScriptObject(LiFxTradepostLoaderSelect)
  {
  };
}

package LiFxTradepostLoaderSelect

{
  function LiFxTradepostLoaderSelect::setup() {
   LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, initArrays, LiFxTradepostLoaderSelect);
   LiFx::registerCallback($LiFx::hooks::onInitServerDBChangesCallbacks, LoadFiles, LiFxTradepostLoaderSelect);

  }
  

// Set up all of the arrays
// with default values
function LiFxTradepostLoaderSelect::initArrays() {

   // Initialize single dimensional array
   // containing a list of names
   $StandardTrade[0] = exec("TradeOptions/StandardTrade.cs");
   $MarketCrash[1] = exec("TradeOptions/CrashTrade.cs");
   $Goodtrade[2] = exec("TradeOptions/GoodTrade.cs");
   $HiSelltrade[3] = exec("TradeOptions/HighsellTrade.cs");
   $LowSelltrade[4] = exec("TradeOptions/LowsellTrade.cs");
   
function TriggerData(LiFxTradepostLoaderSelectTrigger)
{
    local = 1;
    tickPeriodMs = 10800;
};
if(!isDefined("$LiFx::LiFxTradepostLoaderSelect::timeToTraderest"))
{
  echo("Trade Refresh Timer not configured, setting default 3 hours");
  $LiFx::LiFxTradepostLoaderSelect::timeToTraderest = 1; //1 = 3 hours
}
   // Initialize for array

   function LiFxTradepostLoaderSelect::LoadFiles() {
   // Iterate through the names
   // array and print the values
   for(%i = 0; %i < 5; %i++)
      echo(%i @ ": " @ $names[%i]);
    }
  }
  function LiFxTradepostLoaderSelect::setTradeValue(%this)
{

   // Set the Trade value
   $Trade[%row, %column] = %this;

   // Check to see if we have the same
   // three values in a row
   if(checkForUpdate())
   {
      // Print a Trade update message
      echo("\n*********************************");
      echo("*    Tradepost Price update!    *");
      echo("*********************************\n");

      // Load the Trade Values
      checkForUpdate();

      // Reset the Trade Prices
      echo("\nResetting Trade");
      UpdateTrades();
   }
}
};
activatePackage(LiFxTradepostLoaderSelect);
LiFx::registerCallback($LiFx::hooks::mods, setup, LiFxTradepostLoaderSelect);