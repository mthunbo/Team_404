import React, { useEffect, useState } from 'react';
import { Text, View, ScrollView, Image } from 'react-native';
import { useRouter } from 'expo-router';

export default function Dashboard() {
    return (
        <View className='flex-1 flex-col bg-[#B3B3B3] justify-center items-center gap-[35px]'>

            <View className='flex flex-row self-end mr-4 border border-[4px] border-[#797979] rounded-2xl px-[10px] py-[4px]'> {/* Coin display (ONLY CHILDREN VIEW)*/}
                <Text className='text-3xl -mt-[1px] mr-2 text-white font-bold'>150</Text>
                <Image source={require('../assets/Coin.png')} style={{ width: 30, height: 30 }} resizeMode="contain" />
            </View>

            <View className='w-[300px] h-[600px]'>
                <ScrollView className='bg-[#D9D9D9] rounded-lg border border-[5px] border-[#A5A5A5] p-4'>
                    {/* Tasks will be loaded here */}
                </ScrollView>
            </View>
        </View>
    );
}