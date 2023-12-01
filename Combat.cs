using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPfF_Turn_based_Game
{
    internal class Combat
    {
        public static async void DealDamage(Character attacker, Character defender, TextBox statusBar)
        {
            int hitDamage = attacker.EquippedWeapon.Attack();
            int hitDefend = defender.EquippedWeapon.Defend();
            int attackDamage = hitDamage - hitDefend;
            //Character currentPlayer = attacker;


            if (attackDamage > 0)
            {
                defender.RemoveHealth(attackDamage);
                statusBar.Text += $"You struck {defender.Name} causing {attackDamage} points of damage\n";

                ClearTextBoxDelay(statusBar, 2500);
                await Task.Delay(3000);

                if (!defender.IsAlive)
                {
                    statusBar.Text = ($"{defender.Name} is dead. Game Over\n");
                }
                else
                {
                    statusBar.Text = ($"{defender.Name}'s turn\n");
                    ClearTextBoxDelay(statusBar, 2500);
                }


            }
            else
            {
                statusBar.Text += $"{defender.Name} skillfully blocked your attack\n";
                ClearTextBoxDelay(statusBar, 3000);
                await Task.Delay(3500);
                statusBar.Text = ($"{defender.Name}'s turn\n");
                ClearTextBoxDelay(statusBar, 3000);
            }

            statusBar.Text += $"{defender.Name}'s current health is {defender.Health}\n";

            //if (!defender.IsAlive)
            //{
            //    statusBar.Text += $"\nYou delivered a fatal blow !!\n";
            //    statusBar.Text += $"\n==== {defender.Name} is dead. ====\n";
            //}
        }
        public async static void ClearTextBoxDelay(TextBox textBox, int delayMilliseconds)
        {
            await Task.Delay(delayMilliseconds);
            textBox.Text = string.Empty;

        }
    }
}
