using System.Windows;

namespace WPfF_Turn_based_Game
{
    /// <summary>
    /// Interaction logic for WeaponSelection.xaml
    /// </summary>
    public partial class WeaponSelection : Window
    {
        public Weapon selectedWeapon { get; set; }
        public WeaponSelection()
        {
            InitializeComponent();
        }

        public void Select_Sword_Click(object sender, RoutedEventArgs e)
        {

            selectedWeapon = Weapon.CreateSword();

            Close();
        }
        public void Select_Axe_Click(object sender, RoutedEventArgs e)
        {

            selectedWeapon = Weapon.CreateAxe();

            Close();
        }
    }

}
