// ==========
// MODIFIERS/INFO
// ==========

function getMoneyValue(isModified, luckValue, capsuleType){
    let upgradeFactor = isModified ? mults.upgradeKnightFactor : 1;
    return luckValue / mults.knightSellFactor * mults.knightCapsuleSellFactor[capsuleType] * upgradeFactor;
}

var mults = {
    upgradeKnightFactor: 0.025, // Modified figurine
    knightSellFactor: 2000, // Standard sell value
    knightMuseumFactor: 1000, // Museum multiplier
    knightCapsuleSellFactor: { // Shinyness
        None: 1,
        Silver: 10,
        Gold: 100,
        Red: 1000,
        Black: 10000,
    },
    capeMultiplier: 5, // Cape
    enchantMultiplier: 10, // Enchant
    invertedMultiplier: 250, // Inverted part
    invertedBonusMultiplier: 10, // >1 inverted parts multiplier = bonus^(inverterPartCount-1)
    petMultiplier: 500, // Pet
    shinyPetMultiplier: 2500, // Shiny pet
    leftHandedMultiplier: 2, // Lefthanded
    armorSetMultiplier: 12, // Armor set
    rareArmorSetMultiplier: 120, // Rare armor set
    equipmentsTierMultiplier: 20, // Equipment set
    rareEquipmentsTierMultiplier: 200, // Rare equipment set
    namesTierMultiplier: 20, // Title set
    physicsTierMultiplier: 10, // Face+body set
    enchantsTierMultiplier: 30, // Enchants set
    rareEnchantMultiplier: 50, // Rare enchants set
    rarityValue: { // Normal part rarity multiplier
        Common: 1,
        Uncommon: 2,
        Epic: 10,
        Legendary: 50,
        Mythic: 500
    },
    rareRarityValue: { // Rare part multiplier
        Common: 10,
        Uncommon: 10,
        Epic: 10,
        Legendary: 10,
        Mythic: 10
    },
    specialRarityValue: { // Special part rarity multiplier
        Common: 100,
        Uncommon: 200,
        Epic: 1000,
        Legendary: 5000,
        Mythic: 50000
    },
    setBonusRepartition: [
        [0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 30, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 10, 30, 60, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 5, 15, 35, 65, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 5, 15, 30, 50, 75, 100, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 3, 9, 18, 30, 50, 70, 100, 100, 100, 100, 100, 100, 100, 100],
        [0, 0, 5, 10, 20, 30, 40, 50, 70, 100, 100, 100, 100, 100, 100],
        [0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100, 100, 100, 100],
        [0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100, 100, 100],
        [0, 0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100, 100],
        [0, 0, 0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100, 100],
        [0, 0, 0, 0, 0, 5, 10, 20, 30, 40, 50, 60, 70, 80, 100],
    ]
}

var rankThresholds = {
    Wood: 0,                      //wood
    Tin: 50,                     //Tin
    Copper: 300,                    //Copper
    Iron: 1200,                   //Iron
    Bronze: 5000,                   //Bronze
    Silver: 25000,                  //Silver
    Gold: 100000,                 //Gold
    Platinum: 400000,                 //Platinum
    Mithril: 1200000,                //Mithril
    Orichalcum: 5000000,                //Orichalcum
    Obsidian: 25000000,               //Obsidian
    Amber: 100000000,              //Amber 
    Pearl: 400000000,              //Pearl 
    Coral: 2000000000,             //Coral 
    Jade: 8000000000,             //Jade
    Amethyst: 40000000000,            //Amethyste
    Diamond: 100000000000,           //Diamond
    Ruby: 2000000000000,          //Ruby
    Sapphire: 40000000000000,         //Sapphire
    Emerald: 800000000000000,        //Emerald
    Garnet: 16000000000000000,      //Garnet
    Peridot: 320000000000000000,     //Peridot
    Tanzanite: 6400000000000000000,    //Tanzanite
    Aquamarine: 1E+20,                  //Aquamarine
    Alexandrite: 1E+22,                  //Alexandrite
    Tourmaline: 1E+24,                  //Tourmaline
    Superist: 1E+26,                  //Superist
    Wonderdot: 1E+29,                  //Wonderdot
    Hyperald: 1E+32,                  //Hyperald
    Ultramire: 1E+35,                  //Ultramire
    Megamond: 1E+39,                  //Megamond
    Masterite: 1E+43,                  //Masterite
    Perfectone: 1E+50,                  //Perfectone
    TruePerfectone: 1E+58                   //True Perfectone
};

var invertedRankThresholds = {
    Wood: 0,                      //wood
    Tin: 1E+21,                  //Tin
    Copper: 1E+23,                    //Copper
    Iron: 1E+25,                   //Iron
    Bronze: 1E+27,                   //Bronze
    Silver: 1E+29,                  //Silver
    Gold: 1E+31,                 //Gold
    Platinum: 1E+33,                 //Platinum
    Mithril: 1E+35,                //Mithril
    Orichalcum: 1E+37,                //Orichalcum
    Obsidian: 1E+39,               //Obsidian
    Amber: 1E+41,              //Amber 
    Pearl: 1E+43,              //Pearl 
    Coral: 1E+45,             //Coral 
    Jade: 1E+47,             //Jade
    Amethyst: 1E+49,            //Amethyste
    Diamond: 1E+51,           //Diamond
    Ruby: 1E+53,          //Ruby
    Sapphire: 1E+55,         //Sapphire
    Emerald: 1E+57,        //Emerald
    Garnet: 1E+59,      //Garnet
    Peridot: 1E+62,     //Peridot
    Tanzanite: 1E+65,    //Tanzanite
    Aquamarine: 1E+68,                  //Aquamarine
    Alexandrite: 1E+71,                  //Alexandrite
    Tourmaline: 1E+74,                  //Tourmaline
    Superist: 1E+77,                  //Superist
    Wonderdot: 1E+80,                  //Wonderdot
    Hyperald: 1E+83,                  //Hyperald
    Ultramire: 1E+86,                  //Ultramire
    Megamond: 1E+89,                  //Megamond
    Masterite: 1E+92,                  //Masterite
    Perfectone: 1E+95,                  //Perfectone
    TruePerfectone: 1E+98                   //True Perfectone
}

var rarityDict = ['Common', 'Uncommon', 'Epic', 'Legendary', 'Mythic'];
var knightParts = ['Title', 'Trait', 'Job', 'Face', 'Body', 'Helmet', 'Armor', 'Cape', 'Cape color', 'Mainhand', 'Main enchant', 'Offhand', 'Off enchant', 'Pet', 'Shine'];

// ==========
// CALCULATION
// ==========

function calculatePartValue(part){
    let rarity = document.querySelector('#knight-'+part+'-rarity').value;

    if(rarity == 'None'){
        document.querySelector('#knight-'+part+'-value').innerHTML = 1;
        if(['pet', 'cape', 'mainenchant', 'offenchant'].includes(part)){
            document.querySelector('#knight-visual-'+part).src = '';
        }
        
        return 1;
    }

    var special, inverted;
    if(['helmet','armor','main','offhand','mainenchant','offenchant','pet'].includes(part)){
        special = document.querySelector('#knight-'+part+'-rare').value;
    }else{
        special = 'Normal';
    }
    
    if(!['capecolor','name','trait','job'].includes(part)){
        inverted = document.querySelector('#knight-'+part+'-inverted').checked;
    }else{
        inverted = 0;
    }

    let luck = 1;
    let value = special == 'Special' ? mults.specialRarityValue[rarity] : mults.rarityValue[rarity];

    switch(part){
        case 'armor':
        case 'helmet':
        case 'main':
        case 'offhand':
            if(special == 'Rare')
                luck = mults.rareRarityValue[rarity];
            break;
        case 'mainenchant':
        case 'offenchant':
            luck = mults.enchantMultiplier;
            if(special == 'Rare')
                luck *= mults.rareEnchantMultiplier;
            break;
        case 'cape':
            luck = mults.capeMultiplier;
            luck *= mults.rarityValue[rarity];
            break;
        case 'pet':
            luck = 1;
            value = mults.rarityValue[rarity] * mults.petMultiplier;
            value *= special == 'Special' ? mults.shinyPetMultiplier : 1;
            break;
        default:
            break;
    }

    if(['body', 'face', 'helmet', 'armor', 'main', 'mainenchant', 'offhand', 'offenchant', 'cape', 'pet'].includes(part)){
        let partName = part;
        switch(part){
            case 'main':
                partName = 'main_hand';
                break;
            case 'mainenchant':
                partName = 'main_enchant';
                break;
            case 'offhand':
                partName = 'off_hand';
                break;
            case 'offenchant':
                partName = 'off_enchant';
                break;
            case 'pet':
                partName = 'familiar';
                break;
        }
        
        if(inverted){
            document.querySelector('#knight-visual-'+part).src = './assets/' + rarity.toLowerCase() + '/' + partName + '.png';
            document.querySelector('#knight-visual-'+part).style.filter = 'invert(1)';
        }else{
            document.querySelector('#knight-visual-'+part).src = './assets/' + rarity.toLowerCase() + '/' + partName + '.png';
            document.querySelector('#knight-visual-'+part).style.filter = 'invert(0)';
        }
    }

    let finalValue = luck * value;
    finalValue *= inverted ? mults.invertedMultiplier : 1;
    document.querySelector('#knight-'+part+'-value').innerHTML = finalValue;
    return finalValue;
}

function calculateLuckValue(){
    var parts = [
        'name',
        'trait',
        'job',
        'face',
        'body',
        'helmet',
        'armor',
        'cape',
        'capecolor',
        'main',
        'mainenchant',
        'offhand',
        'offenchant',
        'pet',
    ];

    var partRarities = {};
    var partNames = {};
    var partRares = {};

    var luckValue = 1;
    var invertedCount = 0;

    for(let i = 0; i < parts.length; i++){
        luckValue *= calculatePartValue(parts[i]);
        partRarities[parts[i]] = document.querySelector('#knight-'+parts[i]+'-rarity').value;
        partNames[parts[i]] = document.querySelector('#knight-'+parts[i]+'-part').value;
        if(document.querySelector('#knight-'+parts[i]+'-rare')) partRares[parts[i]] = document.querySelector('#knight-'+parts[i]+'-rare').value;

        if(!['capecolor','name','trait','job'].includes(parts[i])){
            inverted = document.querySelector('#knight-'+parts[i]+'-inverted').checked;
            if(inverted){
                invertedCount++;
            }
        }
    }

    let bonus = 1
    for (const [key, setParts] of Object.entries(knightSetListFull)){
        let setCounter = 0;
        for(let i = 0; i < parts.length; i++){
            if(setParts[i+1] == partNames[parts[i]] && setParts[i+1] != ''){
                setCounter++;
            }
        }
        if(setCounter > 0){
            console.log(key, setCounter+'/'+(setParts.filter(x => x != '').length-1));
        }
        if(setCounter > 1){
            let i = (setParts.filter(x => x != '').length-1) - 2;
            if(i > 0 && i < mults.setBonusRepartition[0].length){
                //console.log('luck was', luckValue)
                //luckValue *= setParts[0] / 100 * mults.setBonusRepartition[i][setCounter-1];
                bonus += setParts[0] / 100 * mults.setBonusRepartition[i][setCounter-1];
                //console.log('now it is', luckValue);
                console.log('from multiplier of', setParts[0] / 100 * mults.setBonusRepartition[i][setCounter-1])
                console.log('from indexes', i, setCounter-1)
            }
        }
    }

    luckValue *= bonus;

    /*
        public double GetSetBonus(KnightData knightToCheck)
        {
            int partcount = 0;
            if(partcount > 1)
            {
                int index = parts.Count - 2;
                if(index < 0 || index >= KnightSets.setBonusRepartition.GetLength(0))
                    return 0;
                
                return setBonus/100.0*KnightSets.setBonusRepartition[index,partcount-1];
            }
            else
                return 0;
        }
    */

    if(invertedCount > 1){
        luckValue *= Math.pow(mults.invertedBonusMultiplier, invertedCount-1);
    }

    if(document.querySelector('#knight-lefthanded').checked){
        luckValue *= mults.leftHandedMultiplier;
    }

    if(partRarities.face == partRarities.body && partRarities.face != 'Common'){
        luckValue *= mults.physicsTierMultiplier;
    }

    if(partRarities.name == partRarities.trait && partRarities.trait == partRarities.job && partRarities.name != 'Common'){
        luckValue *= mults.namesTierMultiplier;
    }

    if(partRarities.mainenchant == partRarities.offenchant && partRarities.mainenchant != 'None'){
        luckValue *= mults.enchantsTierMultiplier;
    }

    if(partNames.helmet == partNames.armor && partRares.helmet != 'Special' && partRares.armor != 'Special'){
        if(partRares.helmet == 'Rare' && partRares.armor == 'Rare'){
            luckValue *= mults.rareArmorSetMultiplier;
        }else{
            luckValue *= mults.armorSetMultiplier;
        }
        
    }

    if(partRarities.armor == partRarities.helmet && partRarities.armor == partRarities.main && partRarities.armor == partRarities.offhand){
        if((partRares.helmet == 'Special' || partRares.helmet == 'Rare')
            && (partRares.helmet == 'Special' || partRares.helmet == 'Rare')
            && (partRares.helmet == 'Special' || partRares.helmet == 'Rare')
            && (partRares.helmet == 'Special' || partRares.helmet == 'Rare')){
                luckValue *= mults.rareEquipmentsTierMultiplier;
            }else if(partRarities.armor != 'Common'){
                luckValue *= mults.equipmentsTierMultiplier;
            }
    }

    console.log('luck value is', luckValue);
    let moneyValue = getMoneyValue(document.querySelector('#knight-modified').checked, luckValue, document.querySelector('#knight-shine').value);
    console.log('money value is', moneyValue);

    document.querySelector('#knight-value-luck').innerHTML = luckValue >= 1000000 ? Math.floor(luckValue).toExponential() : luckValue.toFixed(2);
    document.querySelector('#knight-value-money').innerHTML = moneyValue >= 1000000 ? Math.floor(moneyValue).toExponential() : moneyValue.toFixed(2);

    /*for(let i = 0; i < rankThresholds.length; i++){
        if(rankThresholds[i] > luckValue){
            document.querySelector('#knight-value-rank').innerHTML = rankThresholds[i-1];
            break;
        }
    }*/

    let prev = '';
    let lastRank = false;
    for (const [key, value] of Object.entries(rankThresholds)){
        lastRank = true;
        if(value > luckValue){
            lastRank = false;
            document.querySelector('#knight-value-rank').innerHTML = prev;
            break;
        }else{
            prev = key;
        }
    }

    if(lastRank){
        document.querySelector('#knight-value-rank').innerHTML = prev;
    }
}

// ==========
// UI/UX
// ==========

//console.log(knightPartListFull)

function prepareRarityLists(){

}

function preparePartLists(){
    var parts = {
        name: [],
        trait: [],
        job: [],
        face: [],
        body: [],
        helmet: [],
        armor: [],
        cape: [],
        capecolor: [],
        main: [],
        mainenchant: [],
        offhand: [],
        offenchant: [],
        pet: [],
    }

    var partsRarity = {};

    for (const [key, value] of Object.entries(parts)) {
        let v = document.querySelector('#knight-'+key+'-rarity').value;
        switch(v){
            case 'None':
                v = 999;
                break;
            case 'Common':
                v = 0;
                break;
            case 'Uncommon':
                v = 1;
                break;
            case 'Epic':
                v = 2;
                break;
            case 'Legendary':
                v = 3;
                break;
            case 'Mythic':
                v = 4;
                break;
        }
        partsRarity[key] = v;
    }

    console.log(partsRarity)
    
    for (const [key, value] of Object.entries(knightPartListFull)) {
        let partStr = key.split('_');
        //console.log(`${key}: ${value}`);
        if(key.includes('KNIGHT_NAME') && partStr[2] == partsRarity.name){
            parts.name.push(value);
        }
        if(key.includes('KNIGHT_TRAIT') && partStr[2] == partsRarity.trait){
            parts.trait.push(value);
        }
        if(key.includes('KNIGHT_JOB') && partStr[2] == partsRarity.job){
            parts.job.push(value);
        }
        if(key.includes('KNIGHT_FACE') && partStr[2] == partsRarity.face){
            parts.face.push(value);
        }
        if(key.includes('KNIGHT_BODY') && partStr[2] == partsRarity.body){
            parts.body.push(value);
        }
        if((key.includes('KNIGHT_ARMOR') && partStr[2] == partsRarity.armor) || (key.includes('KNIGHT_SPECIAL_ARMOR') && partStr[3] == partsRarity.armor)){
            parts.armor.push(value);
        }
        if((key.includes('KNIGHT_HELMET') && partStr[2] == partsRarity.helmet) || (key.includes('KNIGHT_SPECIAL_HELMET') && partStr[3] == partsRarity.helmet)){
            parts.helmet.push(value);
        }
        if((key.includes('KNIGHT_MAIN') && partStr[2] == partsRarity.main) || (key.includes('KNIGHT_SPECIAL_MAIN') && partStr[3] == partsRarity.main)){
            parts.main.push(value);
        }
        if((key.includes('KNIGHT_OFF') && partStr[2] == partsRarity.offhand) || (key.includes('KNIGHT_SPECIAL_OFF') && partStr[3] == partsRarity.offhand)){
            parts.offhand.push(value);
        }
        if(key.includes('KNIGHT_ENCHANT') && partStr[2] == partsRarity.mainenchant){
            parts.mainenchant.push(value);
        }
        if(key.includes('KNIGHT_ENCHANT') && partStr[2] == partsRarity.offenchant){
            parts.offenchant.push(value);
        }
        if(key.includes('KNIGHT_CAPE') && !key.includes('KNIGHT_CAPE_COLOR') && partStr[2] == partsRarity.cape){
            parts.cape.push(value);
        }
        if(key.includes('KNIGHT_CAPE_COLOR')){
            parts.capecolor.push(value);
        }
        if(key.includes('KNIGHT_PET') && partStr[2] == partsRarity.pet){
            parts.pet.push(value);
        }
    }

    for (const [key, value] of Object.entries(parts)) {
        let el = document.querySelector('#knight-'+key+'-part');
        $('#knight-'+key+'-part').empty();
        value.sort();
        for(let i = 0; i < value.length; i++){
            el.options.add(new Option(value[i], value[i]));
        }
    }

    //let name = document.querySelector('knight-name-part');

}

function checkSets(part, partName){

}

preparePartLists();
calculateLuckValue();