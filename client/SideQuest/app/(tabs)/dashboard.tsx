import React, { useEffect, useState } from 'react';
import { Text, View, ScrollView } from 'react-native';
import { useRouter } from 'expo-router';

export default function Dashboard() {
    return (
        <View className='flex-1 bg-[#B3B3B3] justify-center items-center'>
            <View className='w-[300px] h-[600px]'>
                <ScrollView className='bg-[#D9D9D9] rounded-lg border border-[5px] border-[#A5A5A5] p-4'>
                    {/* Tasks will be loaded here */}
                </ScrollView>
            </View>
        </View>
    );
}