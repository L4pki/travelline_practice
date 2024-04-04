﻿using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.UI.InputUI
{
    public interface IUIInput
    {
        public IRace ChooseRace();
        public IWeapon ChooseWeapon();
        public IArmor ChooseArmor();
        public Fighter ChooseFighter();
        public string ChooseName();
        public void AboutFighter(IFighter Fighter);

    }
}

