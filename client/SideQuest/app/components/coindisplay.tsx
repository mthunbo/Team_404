import { Text, View, Image } from 'react-native';

export default function CoinDisplay() {
    return (
        <View className='flex flex-row self-end border border-[4px] border-[#797979] rounded-2xl px-[10px] py-[4px]'> 
            <Text className='text-3xl -mt-[1px] mr-2 text-white font-bold'>150</Text>
            <Image source={require('../assets/Coin.png')} style={{ width: 30, height: 30 }} resizeMode="contain" />
        </View>
    );
}