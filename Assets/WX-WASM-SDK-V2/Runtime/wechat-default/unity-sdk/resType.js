export const ResType = {
    AccountInfo: {
        miniProgram: 'MiniProgram',
        plugin: 'Plugin',
    },
    MiniProgram: {
        appId: 'string',
        envVersion: 'string',
        version: 'string',
    },
    Plugin: {
        appId: 'string',
        version: 'string',
    },
    AppAuthorizeSetting: {
        albumAuthorized: 'string',
        bluetoothAuthorized: 'string',
        cameraAuthorized: 'string',
        locationAuthorized: 'string',
        locationReducedAccuracy: 'bool',
        microphoneAuthorized: 'string',
        notificationAlertAuthorized: 'string',
        notificationAuthorized: 'string',
        notificationBadgeAuthorized: 'string',
        notificationSoundAuthorized: 'string',
        phoneCalendarAuthorized: 'string',
    },
    AppBaseInfo: {
        SDKVersion: 'string',
        enableDebug: 'bool',
        host: 'AppBaseInfoHost',
        language: 'string',
        version: 'string',
        theme: 'string',
    },
    AppBaseInfoHost: {
        appId: 'string',
    },
    GetBatteryInfoSyncResult: {
        isCharging: 'bool',
        level: 'number',
    },
    DeviceInfo: {
        abi: 'string',
        benchmarkLevel: 'number',
        brand: 'string',
        cpuType: 'string',
        deviceAbi: 'string',
        memorySize: 'string',
        model: 'string',
        platform: 'string',
        system: 'string',
    },
    EnterOptionsGame: {
        apiCategory: 'string',
        query: 'object',
        referrerInfo: 'EnterOptionsGameReferrerInfo',
        scene: 'number',
        chatType: 'number',
        shareTicket: 'string',
    },
    EnterOptionsGameReferrerInfo: {
        appId: 'string',
        extraData: 'object',
        gameLiveInfo: 'GameLiveInfo',
    },
    GameLiveInfo: {
        streamerOpenId: 'string',
        feedId: 'string',
    },
    LaunchOptionsGame: {
        query: 'object',
        referrerInfo: 'EnterOptionsGameReferrerInfo',
        scene: 'number',
        chatType: 'number',
        shareTicket: 'string',
    },
    ClientRect: {
        bottom: 'number',
        height: 'number',
        left: 'number',
        right: 'number',
        top: 'number',
        width: 'number',
    },
    GetStorageInfoSyncOption: {
        currentSize: 'number',
        keys: 'string[]',
        limitSize: 'number',
    },
    SystemInfo: {
        SDKVersion: 'string',
        albumAuthorized: 'bool',
        benchmarkLevel: 'number',
        bluetoothEnabled: 'bool',
        brand: 'string',
        cameraAuthorized: 'bool',
        deviceOrientation: 'string',
        enableDebug: 'bool',
        fontSizeSetting: 'number',
        host: 'SystemInfoHost',
        language: 'string',
        locationAuthorized: 'bool',
        locationEnabled: 'bool',
        locationReducedAccuracy: 'bool',
        microphoneAuthorized: 'bool',
        model: 'string',
        notificationAlertAuthorized: 'bool',
        notificationAuthorized: 'bool',
        notificationBadgeAuthorized: 'bool',
        notificationSoundAuthorized: 'bool',
        phoneCalendarAuthorized: 'bool',
        pixelRatio: 'number',
        platform: 'string',
        safeArea: 'SafeArea',
        screenHeight: 'number',
        screenWidth: 'number',
        statusBarHeight: 'number',
        system: 'string',
        version: 'string',
        wifiEnabled: 'bool',
        windowHeight: 'number',
        windowWidth: 'number',
        theme: 'string',
    },
    SystemInfoHost: {
        appId: 'string',
    },
    SafeArea: {
        bottom: 'number',
        height: 'number',
        left: 'number',
        right: 'number',
        top: 'number',
        width: 'number',
    },
    SystemSetting: {
        bluetoothEnabled: 'bool',
        deviceOrientation: 'string',
        locationEnabled: 'bool',
        wifiEnabled: 'bool',
    },
    WindowInfo: {
        pixelRatio: 'number',
        safeArea: 'SafeArea',
        screenHeight: 'number',
        screenTop: 'number',
        screenWidth: 'number',
        statusBarHeight: 'number',
        windowHeight: 'number',
        windowWidth: 'number',
    },
    GeneralCallbackResult: {
        errMsg: 'string',
    },
    DownloadFileSuccessCallbackResult: {
        filePath: 'string',
        profile: 'RequestProfile',
        statusCode: 'number',
        tempFilePath: 'string',
        errMsg: 'string',
    },
    RequestProfile: {
        SSLconnectionEnd: 'number',
        SSLconnectionStart: 'number',
        connectEnd: 'number',
        connectStart: 'number',
        domainLookUpEnd: 'number',
        domainLookUpStart: 'number',
        downstreamThroughputKbpsEstimate: 'number',
        estimate_nettype: 'number',
        fetchStart: 'number',
        httpRttEstimate: 'number',
        peerIP: 'string',
        port: 'number',
        protocol: 'string',
        receivedBytedCount: 'number',
        redirectEnd: 'number',
        redirectStart: 'number',
        requestEnd: 'number',
        requestStart: 'number',
        responseEnd: 'number',
        responseStart: 'number',
        rtt: 'number',
        sendBytesCount: 'number',
        socketReused: 'bool',
        throughputKbps: 'number',
        transportRttEstimate: 'number',
    },
    DownloadTaskOnHeadersReceivedListenerResult: {
        header: 'object',
    },
    DownloadTaskOnProgressUpdateListenerResult: {
        progress: 'number',
        totalBytesExpectedToWrite: 'number',
        totalBytesWritten: 'number',
    },
    CreateOpenSettingButtonOption: {
        style: 'OptionStyle',
        type: 'string',
        image: 'string',
        text: 'string',
    },
    OptionStyle: {
        backgroundColor: 'string',
        borderColor: 'string',
        borderRadius: 'number',
        borderWidth: 'number',
        color: 'string',
        fontSize: 'number',
        height: 'number',
        left: 'number',
        lineHeight: 'number',
        textAlign: 'string',
        top: 'number',
        width: 'number',
    },
    ImageData: {
        height: 'number',
        width: 'number',
    },
    GetLogManagerOption: {
        level: 'number',
    },
    Path2D: {},
    OnCheckForUpdateListenerResult: {
        hasUpdate: 'bool',
    },
    VideoDecoderStartOption: {
        source: 'string',
        abortAudio: 'bool',
        abortVideo: 'bool',
        mode: 'number',
    },
    SetMessageToFriendQueryOption: {
        query: 'string',
        shareMessageToFriendScene: 'number',
    },
    AddCardRequestInfo: {
        cardExt: 'string',
        cardId: 'string',
    },
    AddCardSuccessCallbackResult: {
        cardList: 'AddCardResponseInfo[]',
        errMsg: 'string',
    },
    AddCardResponseInfo: {
        cardExt: 'string',
        cardId: 'string',
        code: 'string',
        isSuccess: 'bool',
    },
    AuthPrivateMessageSuccessCallbackResult: {
        encryptedData: 'string',
        errMsg: 'string',
        iv: 'string',
        valid: 'bool',
    },
    CheckIsAddedToMyMiniProgramSuccessCallbackResult: {
        added: 'bool',
        errMsg: 'string',
    },
    ChooseImageSuccessCallbackResult: {
        tempFilePaths: 'string[]',
        tempFiles: 'ImageFile[]',
        errMsg: 'string',
    },
    ImageFile: {
        path: 'string',
        size: 'number',
    },
    ChooseMediaSuccessCallbackResult: {
        tempFiles: 'MediaFile[]',
        type: 'string',
        errMsg: 'string',
    },
    MediaFile: {
        duration: 'number',
        fileType: 'string',
        height: 'number',
        size: 'number',
        tempFilePath: 'string',
        thumbTempFilePath: 'string',
        width: 'number',
    },
    ChooseMessageFileSuccessCallbackResult: {
        tempFiles: 'ChooseFile[]',
        errMsg: 'string',
    },
    ChooseFile: {
        name: 'string',
        path: 'string',
        size: 'number',
        time: 'number',
        type: 'string',
    },
    BluetoothError: {
        errMsg: 'string',
        errCode: 'number',
    },
    CompressImageSuccessCallbackResult: {
        tempFilePath: 'string',
        errMsg: 'string',
    },
    CreateBLEPeripheralServerSuccessCallbackResult: {
        server: 'BLEPeripheralServer',
        errMsg: 'string',
    },
    BLEPeripheralService: {
        characteristics: 'Characteristic[]',
        uuid: 'string',
    },
    Characteristic: {
        uuid: 'string',
        descriptors: 'Descriptor[]',
        permission: 'CharacteristicPermission',
        properties: 'CharacteristicProperties',
        value: 'arrayBuffer',
        arrayBufferLength: 'number',
    },
    Descriptor: {
        uuid: 'string',
        permission: 'DescriptorPermission',
        value: 'arrayBuffer',
        arrayBufferLength: 'number',
    },
    DescriptorPermission: {
        read: 'bool',
        write: 'bool',
    },
    CharacteristicPermission: {
        readEncryptionRequired: 'bool',
        readable: 'bool',
        writeEncryptionRequired: 'bool',
        writeable: 'bool',
    },
    CharacteristicProperties: {
        indicate: 'bool',
        notify: 'bool',
        read: 'bool',
        write: 'bool',
        writeNoResponse: 'bool',
    },
    OnCharacteristicReadRequestListenerResult: {
        callbackId: 'number',
        characteristicId: 'string',
        serviceId: 'string',
    },
    OnCharacteristicSubscribedListenerResult: {
        characteristicId: 'string',
        serviceId: 'string',
    },
    OnCharacteristicWriteRequestListenerResult: {
        callbackId: 'number',
        characteristicId: 'string',
        serviceId: 'string',
        value: 'arrayBuffer',
        arrayBufferLength: 'number',
    },
    AdvertiseReqObj: {
        beacon: 'BeaconInfoObj',
        connectable: 'bool',
        deviceName: 'string',
        manufacturerData: 'ManufacturerData[]',
        serviceUuids: 'string[]',
    },
    BeaconInfoObj: {
        major: 'number',
        minor: 'number',
        uuid: 'string',
        measuredPower: 'number',
    },
    ManufacturerData: {
        manufacturerId: 'string',
        manufacturerSpecificData: 'arrayBuffer',
        arrayBufferLength: 'number',
    },
    FaceDetectSuccessCallbackResult: {
        angleArray: 'FaceAngel',
        confArray: 'FaceConf',
        detectRect: 'object',
        faceInfo: 'IAnyObject[]',
        pointArray: 'IAnyObject[]',
        x: 'number',
        y: 'number',
        errMsg: 'string',
    },
    FaceAngel: {
        pitch: 'number',
        roll: 'number',
        yaw: 'number',
    },
    FaceConf: {
        global: 'number',
        leftEye: 'number',
        mouth: 'number',
        nose: 'number',
        rightEye: 'number',
    },
    GetAvailableAudioSourcesSuccessCallbackResult: {
        errMsg: 'string',
    },
    GetBLEDeviceCharacteristicsSuccessCallbackResult: {
        characteristics: 'BLECharacteristic[]',
        errMsg: 'string',
    },
    BLECharacteristic: {
        properties: 'BLECharacteristicProperties',
        uuid: 'string',
    },
    BLECharacteristicProperties: {
        indicate: 'bool',
        notify: 'bool',
        read: 'bool',
        write: 'bool',
        writeDefault: 'bool',
        writeNoResponse: 'bool',
    },
    GetBLEDeviceRSSISuccessCallbackResult: {
        RSSI: 'number',
        errMsg: 'string',
    },
    GetBLEDeviceServicesSuccessCallbackResult: {
        services: 'BLEService[]',
        errMsg: 'string',
    },
    BLEService: {
        isPrimary: 'bool',
        uuid: 'string',
    },
    GetBLEMTUSuccessCallbackResult: {
        mtu: 'number',
        errMsg: 'string',
    },
    GetBackgroundFetchDataSuccessCallbackResult: {
        fetchedData: 'string',
        path: 'string',
        query: 'string',
        scene: 'number',
        timeStamp: 'long',
        errMsg: 'string',
    },
    GetBackgroundFetchTokenSuccessCallbackResult: {
        errMsg: 'string',
        token: 'string',
    },
    GetBatteryInfoSuccessCallbackResult: {
        isCharging: 'bool',
        level: 'number',
        errMsg: 'string',
    },
    BeaconError: {
        errMsg: 'string',
        errCode: 'number',
    },
    GetBeaconsSuccessCallbackResult: {
        beacons: 'BeaconInfo[]',
        errMsg: 'string',
    },
    BeaconInfo: {
        accuracy: 'number',
        major: 'number',
        minor: 'number',
        proximity: 'number',
        rssi: 'number',
        uuid: 'string',
    },
    GetBluetoothAdapterStateSuccessCallbackResult: {
        available: 'bool',
        discovering: 'bool',
        errMsg: 'string',
    },
    GetBluetoothDevicesSuccessCallbackResult: {
        devices: 'BlueToothDevice[]',
        errMsg: 'string',
    },
    BlueToothDevice: {
        RSSI: 'number',
        advertisData: 'arrayBuffer',
        arrayBufferLength: 'number',
        advertisServiceUUIDs: 'string[]',
        connectable: 'bool',
        deviceId: 'string',
        localName: 'string',
        name: 'string',
        serviceData: 'object',
    },
    GetChannelsLiveInfoSuccessCallbackResult: {
        description: 'string',
        feedId: 'string',
        headUrl: 'string',
        nickname: 'string',
        nonceId: 'string',
        otherInfos: 'AnyKeyword[]',
        replayStatus: 'number',
        status: 'number',
        errMsg: 'string',
    },
    GetChannelsLiveNoticeInfoSuccessCallbackResult: {
        headUrl: 'string',
        nickname: 'string',
        noticeId: 'string',
        otherInfos: 'AnyKeyword[]',
        reservable: 'bool',
        startTime: 'string',
        status: 'number',
        errMsg: 'string',
    },
    GetClipboardDataSuccessCallbackOption: {
        data: 'string',
        errMsg: 'string',
    },
    GetConnectedBluetoothDevicesSuccessCallbackResult: {
        devices: 'BluetoothDeviceInfo[]',
        errMsg: 'string',
    },
    BluetoothDeviceInfo: {
        deviceId: 'string',
        name: 'string',
    },
    GetExtConfigSuccessCallbackResult: {
        extConfig: 'object',
        errMsg: 'string',
    },
    GetFuzzyLocationSuccessCallbackResult: {
        latitude: 'number',
        longitude: 'number',
        errMsg: 'string',
    },
    DataType: {
        type: 'number',
        subKey: 'string',
    },
    GetGameClubDataSuccessCallbackResult: {
        cloudID: 'string',
        encryptedData: 'string',
        iv: 'string',
        signature: 'string',
        errMsg: 'string',
    },
    GetGroupEnterInfoSuccessCallbackResult: {
        cloudID: 'string',
        encryptedData: 'string',
        errMsg: 'string',
        iv: 'string',
    },
    GetInferenceEnvInfoSuccessCallbackResult: {
        ver: 'string',
        errMsg: 'string',
    },
    GetLocalIPAddressSuccessCallbackResult: {
        errMsg: 'string',
        localip: 'string',
        netmask: 'string',
    },
    GetNetworkTypeSuccessCallbackResult: {
        hasSystemProxy: 'bool',
        networkType: 'string',
        signalStrength: 'number',
        errMsg: 'string',
    },
    GetPrivacySettingSuccessCallbackResult: {
        needAuthorization: 'bool',
        privacyContractName: 'string',
        errMsg: 'string',
    },
    GetScreenBrightnessSuccessCallbackOption: {
        value: 'number',
        errMsg: 'string',
    },
    GetScreenRecordingStateSuccessCallbackResult: {
        state: 'string',
        errMsg: 'string',
    },
    GetSettingSuccessCallbackResult: {
        authSetting: 'AuthSetting',
        subscriptionsSetting: 'SubscriptionsSetting',
        miniprogramAuthSetting: 'AuthSetting',
        errMsg: 'string',
    },
    AuthSetting: {},
    SubscriptionsSetting: {
        mainSwitch: 'bool',
        itemSettings: 'object',
    },
    GetStorageInfoSuccessCallbackOption: {
        currentSize: 'number',
        keys: 'string[]',
        limitSize: 'number',
        errMsg: 'string',
    },
    GetUserInfoSuccessCallbackResult: {
        cloudID: 'string',
        encryptedData: 'string',
        iv: 'string',
        rawData: 'string',
        signature: 'string',
        userInfo: 'UserInfo',
        errMsg: 'string',
    },
    UserInfo: {
        avatarUrl: 'string',
        city: 'string',
        country: 'string',
        gender: 'number',
        language: 'string',
        nickName: 'string',
        province: 'string',
    },
    GetUserInteractiveStorageFailCallbackResult: {
        errCode: 'number',
        errMsg: 'string',
    },
    GetUserInteractiveStorageSuccessCallbackResult: {
        cloudID: 'string',
        encryptedData: 'string',
        iv: 'string',
        errMsg: 'string',
    },
    GetWeRunDataSuccessCallbackResult: {
        cloudID: 'string',
        encryptedData: 'string',
        iv: 'string',
        errMsg: 'string',
    },
    JoinVoIPChatError: {
        errMsg: 'string',
        errCode: 'number',
    },
    MuteConfig: {
        muteEarphone: 'bool',
        muteMicrophone: 'bool',
    },
    JoinVoIPChatSuccessCallbackResult: {
        errCode: 'number',
        errMsg: 'string',
        openIdList: 'string[]',
    },
    RequestFailCallbackErr: {
        errMsg: 'string',
        errno: 'number',
    },
    LoginSuccessCallbackResult: {
        code: 'string',
        errMsg: 'string',
    },
    OnAccelerometerChangeListenerResult: {
        x: 'number',
        y: 'number',
        z: 'number',
    },
    OnAddToFavoritesListenerResult: {
        disableForward: 'bool',
        imageUrl: 'string',
        query: 'string',
        title: 'string',
    },
    OnBLECharacteristicValueChangeListenerResult: {
        characteristicId: 'string',
        deviceId: 'string',
        serviceId: 'string',
        value: 'arrayBuffer',
        arrayBufferLength: 'number',
    },
    OnBLEConnectionStateChangeListenerResult: {
        connected: 'bool',
        deviceId: 'string',
    },
    OnBLEMTUChangeListenerResult: {
        deviceId: 'string',
        mtu: 'number',
    },
    OnBLEPeripheralConnectionStateChangedListenerResult: {
        connected: 'bool',
        deviceId: 'string',
        serverId: 'string',
    },
    OnBackgroundFetchDataListenerResult: {
        fetchType: 'string',
        fetchedData: 'string',
        path: 'string',
        query: 'string',
        scene: 'number',
        timeStamp: 'long',
    },
    OnBeaconServiceChangeListenerResult: {
        available: 'bool',
        discovering: 'bool',
    },
    OnBeaconUpdateListenerResult: {
        beacons: 'BeaconInfo[]',
    },
    OnBluetoothAdapterStateChangeListenerResult: {
        available: 'bool',
        discovering: 'bool',
    },
    OnBluetoothDeviceFoundListenerResult: {
        devices: 'BlueToothDevice[]',
    },
    OnCompassChangeListenerResult: {
        accuracy: 'string',
        direction: 'number',
    },
    OnCopyUrlListenerResult: {
        query: 'string',
    },
    OnDeviceMotionChangeListenerResult: {
        alpha: 'number',
        beta: 'number',
        gamma: 'number',
    },
    OnDeviceOrientationChangeListenerResult: {
        value: 'string',
    },
    Error: {
        message: 'string',
        stack: 'string',
    },
    OnGyroscopeChangeListenerResult: {
        x: 'number',
        y: 'number',
        z: 'number',
    },
    OnHandoffListenerResult: {
        query: 'string',
    },
    OnKeyDownListenerResult: {
        code: 'string',
        key: 'string',
        timeStamp: 'long',
    },
    OnKeyboardInputListenerResult: {
        value: 'string',
    },
    OnKeyboardHeightChangeListenerResult: {
        height: 'number',
    },
    OnMemoryWarningListenerResult: {
        level: 'number',
    },
    OnMouseDownListenerResult: {
        button: 'number',
        timeStamp: 'long',
        x: 'number',
        y: 'number',
    },
    OnMouseMoveListenerResult: {
        movementX: 'number',
        movementY: 'number',
        timeStamp: 'long',
        x: 'number',
        y: 'number',
    },
    OnNetworkStatusChangeListenerResult: {
        isConnected: 'bool',
        networkType: 'string',
    },
    OnNetworkWeakChangeListenerResult: {
        networkType: 'string',
        weakNet: 'bool',
    },
    OnScreenRecordingStateChangedListenerResult: {
        state: 'string',
    },
    OnShareTimelineListenerResult: {
        imageUrl: 'string',
        imagePreviewUrl: 'string',
        imagePreviewUrlId: 'string',
        imageUrlId: 'string',
        path: 'string',
        query: 'string',
        title: 'string',
    },
    OnShowListenerResult: {
        query: 'object',
        referrerInfo: 'ResultReferrerInfo',
        scene: 'number',
        chatType: 'number',
        shareTicket: 'string',
    },
    ResultReferrerInfo: {
        appId: 'string',
        extraData: 'object',
    },
    OnUnhandledRejectionListenerResult: {
        promise: 'string',
        reason: 'string',
    },
    OnVoIPChatInterruptedListenerResult: {
        errCode: 'number',
        errMsg: 'string',
    },
    OnVoIPChatMembersChangedListenerResult: {
        errCode: 'number',
        errMsg: 'string',
        openIdList: 'string[]',
    },
    OnVoIPChatSpeakersChangedListenerResult: {
        errCode: 'number',
        errMsg: 'string',
        openIdList: 'string[]',
    },
    OnVoIPChatStateChangedListenerResult: {
        code: 'number',
        data: 'object',
        errCode: 'number',
        errMsg: 'string',
    },
    OnWheelListenerResult: {
        deltaX: 'number',
        deltaY: 'number',
        deltaZ: 'number',
        timeStamp: 'long',
        x: 'number',
        y: 'number',
    },
    OnWindowResizeListenerResult: {
        windowHeight: 'number',
        windowWidth: 'number',
    },
    OpenCardRequestInfo: {
        cardId: 'string',
        code: 'string',
    },
    ExtInfoOption: {
        url: 'string',
    },
    OpenCustomerServiceConversationSuccessCallbackResult: {
        path: 'string',
        query: 'object',
        errMsg: 'string',
    },
    OpenSettingSuccessCallbackResult: {
        authSetting: 'AuthSetting',
        subscriptionsSetting: 'SubscriptionsSetting',
        errMsg: 'string',
    },
    OperateGameRecorderVideoOption: {
        atempo: 'number',
        audioMix: 'bool',
        bgm: 'string',
        desc: 'string',
        path: 'string',
        query: 'string',
        timeRange: 'number[]',
        title: 'string',
        volume: 'number',
    },
    MediaSource: {
        url: 'string',
        poster: 'string',
        type: 'string',
    },
    ReportSceneError: {
        errMsg: 'string',
        errCode: 'number',
    },
    ReportSceneFailCallbackErr: {
        data: 'object',
        errMsg: 'string',
    },
    ReportSceneSuccessCallbackResult: {
        data: 'object',
        errMsg: 'string',
    },
    ReportUserBehaviorBranchAnalyticsOption: {
        branchId: 'string',
        eventType: 'number',
        branchDim: 'string',
    },
    MidasFriendPaymentError: {
        errMsg: 'string',
        errCode: 'number',
    },
    RequestMidasFriendPaymentSuccessCallbackResult: {
        cloudID: 'string',
        encryptedData: 'string',
        errMsg: 'string',
        iv: 'string',
    },
    MidasPaymentError: {
        errMsg: 'string',
        errCode: 'number',
    },
    RequestMidasPaymentFailCallbackErr: {
        errCode: 'number',
        errMsg: 'string',
    },
    RequestMidasPaymentSuccessCallbackResult: {
        errMsg: 'string',
    },
    RequestSubscribeMessageFailCallbackResult: {
        errCode: 'number',
        errMsg: 'string',
    },
    RequestSubscribeMessageSuccessCallbackResult: {
        anyKeyWord: 'string',
        errMsg: 'string',
    },
    RequestSubscribeSystemMessageSuccessCallbackResult: {
        anyKeyWord: 'string',
        errMsg: 'string',
    },
    ReserveChannelsLiveOption: {
        noticeId: 'string',
    },
    ScanCodeSuccessCallbackResult: {
        charSet: 'string',
        path: 'string',
        rawData: 'string',
        result: 'string',
        scanType: 'string',
        errMsg: 'string',
    },
    SetBLEMTUFailCallbackResult: {
        mtu: 'number',
    },
    SetBLEMTUSuccessCallbackResult: {
        mtu: 'number',
        errMsg: 'string',
    },
    KVData: {
        key: 'string',
        value: 'string',
    },
    ShareAppMessageOption: {
        imageUrl: 'string',
        imageUrlId: 'string',
        path: 'string',
        query: 'string',
        title: 'string',
        toCurrentGroup: 'bool',
    },
    ShowActionSheetSuccessCallbackResult: {
        tapIndex: 'number',
        errMsg: 'string',
    },
    ShowModalSuccessCallbackResult: {
        cancel: 'bool',
        confirm: 'bool',
        content: 'string',
        errMsg: 'string',
    },
    UpdatableMessageFrontEndTemplateInfo: {
        parameterList: 'UpdatableMessageFrontEndParameter[]',
    },
    UpdatableMessageFrontEndParameter: {
        name: 'string',
        value: 'string',
    },
    VibrateShortFailCallbackResult: {
        errMsg: 'string',
    },
    CheckGameLiveEnabledSuccessCallbackOption: {
        errMsg: 'string',
        isEnabled: 'bool',
    },
    OnGameLiveStateChangeCallbackResult: {
        state: 'string',
        feedId: 'string',
    },
    OnGameLiveStateChangeCallbackResponse: {
        query: 'string',
    },
    GameLiveState: {
        isLive: 'bool',
    },
    GetUserCurrentGameliveInfoSuccessCallbackOption: {
        feedIdList: 'string[]',
    },
    GetUserGameLiveDetailsSuccessCallbackOption: {
        encryptedData: 'string',
        iv: 'string',
        cloudID: 'string',
        feedIdList: 'string[]',
        errMsg: 'string',
    },
    MidasPaymentGameItemError: {
        errMsg: 'string',
        errCode: 'number',
    },
    RequestSubscribeLiveActivitySuccessCallbackResult: {
        code: 'string',
        errMsg: 'string',
    },
    FrameDataOptions: {
        data: 'arrayBuffer',
        arrayBufferLength: 'number',
        height: 'number',
        pkDts: 'number',
        pkPts: 'number',
        width: 'number',
    },
};
