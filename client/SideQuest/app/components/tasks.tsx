import React, { useEffect, useState } from 'react';
import { Text, View, Image, TouchableOpacity, } from 'react-native';
import Animated, { FadeInUp, FadeOutUp, LinearTransition } from 'react-native-reanimated';


export default function Tasks() {
    const [openTaskId, setOpenTaskId] = useState<number | null>(null);

    const tasks = [
        {
            id: 1,
            title: 'Walk the dog',
            coins: 10,
            color: '#F24822',
            state: 'notStarted',
            description: 'Take the dog for a 30 minute walk around the block.',
        },
        {
            id: 2,
            title: 'Do the dishes',
            coins: 15,
            color: '#FFC943',
            state: 'inProgress',
            description: 'Wash all plates, cups, and pans after dinner.',
        },
        {
            id: 3,
            title: 'Vacuum the house',
            coins: 25,
            color: '#66D575',
            state: 'completed',
            description: 'Vacuum all rooms, including under the couch.',
        },
        {
        id: 4,
        title: 'Mow the lawn',
        coins: 40,
        color: '#F24822', // Red
        state: 'notStarted',
        description: 'Mow the front and back yard. Please trim the edges near the fence.',
    },
    {
        id: 5,
        title: 'Water the plants',
        coins: 5,
        color: '#66D575', // Green
        state: 'completed',
        description: 'Give the indoor succulents and the outdoor garden beds a good drink.',
    },
    {
        id: 6,
        title: 'Grocery shopping',
        coins: 20,
        color: '#FFC943', // Yellow
        state: 'inProgress',
        description: 'Pick up milk, eggs, bread, and the ingredients for Friday night dinner.',
    },
    {
        id: 7,
        title: 'Clean the windows',
        coins: 30,
        color: '#F24822',
        state: 'notStarted',
        description: 'Use the glass cleaner to wipe down the living room and kitchen windows.',
    },
    {
        id: 8,
        title: 'Fold the laundry',
        coins: 12,
        color: '#FFC943',
        state: 'inProgress',
        description: 'Fold the basket of clean clothes and put them away in the dresser.',
    },
    {
        id: 9,
        title: 'Take out the trash',
        coins: 8,
        color: '#66D575',
        state: 'completed',
        description: 'Empty all small bins and take the main bag out to the curb.',
    },
    {
        id: 10,
        title: 'Organize the bookshelf',
        coins: 15,
        color: '#F24822',
        state: 'notStarted',
        description: 'Sort the books by color or genre and wipe off any dust from the shelves.',
    },
    ];
    return (
        <View className='flex flex-col justify-center gap-[25px] mt-3 mb-[30px]'> 
            {tasks.map(task => {
                const isOpen = openTaskId === task.id;
                return (
                    <Animated.View layout={LinearTransition} key={task.id}>
                        <TouchableOpacity activeOpacity={0.8} onPress={() =>
                            setOpenTaskId(isOpen ? null : task.id)
                        }>
                            <View className='flex flex-row justify-between items-center p-4 rounded-lg' style={{backgroundColor: task.color}}>
                                <View>
                                    <Text className='text-white font-bold text-md'>{task.title}</Text>
                                </View>

                                <View className='flex flex-row'>
                                    <Text className='text-lg font-bold text-white mr-2'>{task.coins}</Text>
                                    <Image source={require('../assets/Coin.png')} className='mt-[3px]' style={{ width: 20, height: 20 }} resizeMode="contain" />
                                </View>
                            </View>
                        </TouchableOpacity>
                        {isOpen && (
                            <Animated.View 
                                className='flex flex-col justify-center items-center bg-[#C9C9C9] mt-1 rounded-lg p-2'
                                entering={FadeInUp.duration(300)}
                                exiting={FadeOutUp.duration(200)}
                            >
                                <Text className='text-orange-600 text-xl font-bold mb-1'>Quest Description</Text>
                                <View className='bg-[#B3B3B3] border border-3 border-[#A5A5A5] rounded-lg p-2'>
                                    <Text className='text-white text-md'>{task.description}</Text>
                                </View>
                                {task.state === 'notStarted' && (
                                    <TouchableOpacity activeOpacity={0.8}>
                                        <View className='bg-[#4AB659] rounded-lg mt-4 p-2'>
                                            <Text className='text-white text-sm font-bold'>Take quest</Text>
                                        </View> 
                                    </TouchableOpacity>
                                )}

                                {task.state === 'inProgress' && (
                                    <View className='flex flex-row justify-between gap-4'>
                                        <TouchableOpacity activeOpacity={0.8}>
                                            <View className='bg-[#FB390E] rounded-lg mt-4 p-2'>
                                                <Text className='text-white text-sm font-bold'>Cancel quest</Text>
                                            </View> 
                                        </TouchableOpacity>

                                        <TouchableOpacity activeOpacity={0.8}>
                                            <View className='bg-[#4AB659] rounded-lg mt-4 p-2'>
                                                <Text className='text-white text-sm font-bold'>Complete quest</Text>
                                            </View> 
                                        </TouchableOpacity>
                                        
                                    </View>
                                )}

                                {task.state === 'completed' && (
                                    <View className='mt-4'>
                                        <Text className='text-green-600 text-sm font-bold'>Waiting for approval</Text>
                                    </View> 
                                )}
                            </Animated.View>
                        )}
                    </Animated.View>
                );
            })}
        </View>
    );

}