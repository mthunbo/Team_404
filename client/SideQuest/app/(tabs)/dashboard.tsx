import React, { useEffect, useState } from 'react';
import { Text, View, ScrollView, Image, TouchableOpacity } from 'react-native';
import {Ionicons} from '@expo/vector-icons';
import { useRouter } from 'expo-router';
import Tasks from '../components/tasks'

export default function Dashboard() {
    const router = useRouter();

    return (
        <View className='flex-1 flex-col bg-[#B3B3B3] justify-center items-center gap-[20px]'>

            <View className='flex flex-row justify-between px-6 w-full'>
                {/* Settings button */}
                <View>
                    <TouchableOpacity onPress={() => router.push('/settings')}>
                        <Ionicons name='settings-sharp' color={'#fff'} size={40} />
                    </TouchableOpacity>
                </View>

                {/* Parrent view */}
                <View className='flex flex-row self-end'>
                    <TouchableOpacity onPress={() => alert('Button pressed!')}><Ionicons name='add' color={'#fff'} size={40}></Ionicons></TouchableOpacity>
                </View>

                {/*
                <View className='flex flex-row self-end mr-4 border border-[4px] border-[#797979] rounded-2xl px-[10px] py-[4px]'> // Coin display (ONLY CHILDREN VIEW)
                    <Text className='text-3xl -mt-[1px] mr-2 text-white font-bold'>150</Text>
                    <Image source={require('../assets/Coin.png')} style={{ width: 30, height: 30 }} resizeMode="contain" />
                </View>
                */}
            </View>

                <Text className='text-orange-600 text-4xl font-bold'>Quests</Text>

            <View className='w-[300px] h-[600px]'>
                <ScrollView className='bg-[#D9D9D9] rounded-xl border border-[5px] border-[#A5A5A5] p-4'>
                    {/* Tasks will be loaded here */}
                    <Tasks/>
                </ScrollView>
            </View>
        </View>
    );
}