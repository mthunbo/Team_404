import React, { useEffect, useState } from 'react';
import { Text, View, Image } from 'react-native';


export default function Tasks() {

    return (
        <View className='flex flex-col justify-center gap-[25px]'> {/* Task Container */}
            <View className='flex flex-row justify-between bg-[#F24822] p-4 rounded-lg'> {/* No user assigned */}
                <View className='self-start'>
                    <Text className='text-white font-bold text-xl'>Walk the dog</Text>
                </View>

                <View className='flex flex-row'> {/* Coins */}
                    <Text className='text-xl font-bold text-white mr-3'>10</Text>
                    <Image source={require('../assets/Coin.png')} className='mt-[3px]' style={{ width: 20, height: 20 }} resizeMode="contain" />
                </View>
            </View>

            <View className='flex flex-row justify-between bg-[#FFC943] p-4 rounded-lg'> {/* user assigned */}
                <View className='self-start'>
                    <Text className='text-white font-bold text-xl'>Do the dishes</Text>
                </View>

                <View className='flex flex-row'> {/* Coins */}
                    <Text className='text-xl font-bold text-white mr-3'>10</Text>
                    <Image source={require('../assets/Coin.png')} className='mt-[3px]' style={{ width: 20, height: 20 }} resizeMode="contain" />
                </View>
            </View>

            <View className='flex flex-row justify-between bg-[#66D575] p-4 rounded-lg'> {/* user done/pending */}
                <View className='self-start'>
                    <Text className='text-white font-bold text-xl'>Vacuum the house</Text>
                </View>

                <View className='flex flex-row'> {/* Coins */}
                    <Text className='text-xl font-bold text-white mr-3'>25</Text>
                    <Image source={require('../assets/Coin.png')} className='mt-[3px]' style={{ width: 20, height: 20 }} resizeMode="contain" />
                </View>
            </View>
        </View>
    );
}