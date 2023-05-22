declare module Binaryen {

  type Type = number;

  const none: Type;
  const i32: Type;
  const i64: Type;
  const f32: Type;
  const f64: Type;
  const v128: Type;
  const funcref: Type;
  const externref: Type;
  const anyref: Type;
  const eqref: Type;
  const i31ref: Type;
  const dataref: Type;
  const unreachable: Type;
  const auto: Type;

  function createType(types: Type[]): Type;
  function expandType(type: Type): Type[];

  const enum ExpressionIds {
    Invalid,
    Block,
    If,
    Loop,
    Break,
    Switch,
    Call,
    CallIndirect,
    LocalGet,
    LocalSet,
    GlobalGet,
    GlobalSet,
    Load,
    Store,
    Const,
    Unary,
    Binary,
    Select,
    Drop,
    Return,
    MemorySize,
    MemoryGrow,
    Nop,
    Unreachable,
    AtomicCmpxchg,
    AtomicRMW,
    AtomicWait,
    AtomicNotify,
    AtomicFence,
    SIMDExtract,
    SIMDReplace,
    SIMDShuffle,
    SIMDTernary,
    SIMDShift,
    SIMDLoad,
    MemoryInit,
    DataDrop,
    MemoryCopy,
    MemoryFill,
    RefNull,
    RefIsNull,
    RefFunc,
    RefEq,
    Try,
    Throw,
    Rethrow,
    TupleMake,
    TupleExtract,
    Pop,
    I31New,
    I31Get,
    CallRef,
    RefTest,
    RefCast,
    BrOnCast,
    RttCanon,
    RttSub,
    StructNew,
    StructGet,
    StructSet,
    ArrayNew,
    ArrayGet,
    ArraySet,
    ArrayLen
  }

  const InvalidId: ExpressionIds;
  const BlockId: ExpressionIds;
  const IfId: ExpressionIds;
  const LoopId: ExpressionIds;
  const BreakId: ExpressionIds;
  const SwitchId: ExpressionIds;
  const CallId: ExpressionIds;
  const CallIndirectId: ExpressionIds;
  const LocalGetId: ExpressionIds;
  const LocalSetId: ExpressionIds;
  const GlobalGetId: ExpressionIds;
  const GlobalSetId: ExpressionIds;
  const TableGetId: ExpressionIds;
  const TableSetId: ExpressionIds;
  const TableSizeId: ExpressionIds;
  const TableGrowId: ExpressionIds;
  const LoadId: ExpressionIds;
  const StoreId: ExpressionIds;
  const ConstId: ExpressionIds;
  const UnaryId: ExpressionIds;
  const BinaryId: ExpressionIds;
  const SelectId: ExpressionIds;
  const DropId: ExpressionIds;
  const ReturnId: ExpressionIds;
  const NopId: ExpressionIds;
  const UnreachableId: ExpressionIds;
  const PopId: ExpressionIds;
  const MemorySizeId: ExpressionIds;
  const MemoryGrowId: ExpressionIds;
  const AtomicRMWId: ExpressionIds;
  const AtomicCmpxchgId: ExpressionIds;
  const AtomicWaitId: ExpressionIds;
  const AtomicNotifyId: ExpressionIds;
  const AtomicFenceId: ExpressionIds;
  const SIMDExtractId: ExpressionIds;
  const SIMDReplaceId: ExpressionIds;
  const SIMDShuffleId: ExpressionIds;
  const SIMDTernaryId: ExpressionIds;
  const SIMDShiftId: ExpressionIds;
  const SIMDLoadId: ExpressionIds;
  const SIMDLoadStoreLaneId: ExpressionIds;
  const MemoryInitId: ExpressionIds;
  const DataDropId: ExpressionIds;
  const MemoryCopyId: ExpressionIds;
  const MemoryFillId: ExpressionIds;
  const RefNullId: ExpressionIds;
  const RefIsId: ExpressionIds;
  const RefAsId: ExpressionIds;
  const RefFuncId: ExpressionIds;
  const RefEqId: ExpressionIds;
  const TryId: ExpressionIds;
  const ThrowId: ExpressionIds;
  const RethrowId: ExpressionIds;
  const TupleMakeId: ExpressionIds;
  const TupleExtractId: ExpressionIds;
  const I31NewId: ExpressionIds;
  const I31GetId: ExpressionIds;
  const CallRefId: ExpressionIds;
  const RefTestId: ExpressionIds;
  const RefCastId: ExpressionIds;
  const BrOnCastId: ExpressionIds;
  const RttCanonId: ExpressionIds;
  const RttSubId: ExpressionIds;
  const StructNewId: ExpressionIds;
  const StructGetId: ExpressionIds;
  const StructSetId: ExpressionIds;
  const ArrayNewId: ExpressionIds;
  const ArrayGetId: ExpressionIds;
  const ArraySetId: ExpressionIds;
  const ArrayLenId: ExpressionIds;

  const enum ExternalKinds {
    Function,
    Table,
    Memory,
    Global,
    Tag
  }

  const ExternalFunction: ExternalKinds;
  const ExternalTable: ExternalKinds;
  const ExternalMemory: ExternalKinds;
  const ExternalGlobal: ExternalKinds;
  const ExternalTag: ExternalKinds;

  enum Features {
    MVP,
    Atomics,
    BulkMemory,
    MutableGlobals,
    NontrappingFPToInt,
    SignExt,
    SIMD128,
    ExceptionHandling,
    TailCall,
    ReferenceTypes,
    Multivalue,
    GC,
    Memory64,
    TypedFunctionReferences,
    RelaxedSIMD,
    All
  }

  const enum Operations {
    ClzInt32,
    CtzInt32,
    PopcntInt32,
    NegFloat32,
    AbsFloat32,
    CeilFloat32,
    FloorFloat32,
    TruncFloat32,
    NearestFloat32,
    SqrtFloat32,
    EqZInt32,
    ClzInt64,
    CtzInt64,
    PopcntInt64,
    NegFloat64,
    AbsFloat64,
    CeilFloat64,
    FloorFloat64,
    TruncFloat64,
    NearestFloat64,
    SqrtFloat64,
    EqZInt64,
    ExtendSInt32,
    ExtendUInt32,
    WrapInt64,
    TruncSFloat32ToInt32,
    TruncSFloat32ToInt64,
    TruncUFloat32ToInt32,
    TruncUFloat32ToInt64,
    TruncSFloat64ToInt32,
    TruncSFloat64ToInt64,
    TruncUFloat64ToInt32,
    TruncUFloat64ToInt64,
    TruncSatSFloat32ToInt32,
    TruncSatSFloat32ToInt64,
    TruncSatUFloat32ToInt32,
    TruncSatUFloat32ToInt64,
    TruncSatSFloat64ToInt32,
    TruncSatSFloat64ToInt64,
    TruncSatUFloat64ToInt32,
    TruncSatUFloat64ToInt64,
    ReinterpretFloat32,
    ReinterpretFloat64,
    ConvertSInt32ToFloat32,
    ConvertSInt32ToFloat64,
    ConvertUInt32ToFloat32,
    ConvertUInt32ToFloat64,
    ConvertSInt64ToFloat32,
    ConvertSInt64ToFloat64,
    ConvertUInt64ToFloat32,
    ConvertUInt64ToFloat64,
    PromoteFloat32,
    DemoteFloat64,
    ReinterpretInt32,
    ReinterpretInt64,
    ExtendS8Int32,
    ExtendS16Int32,
    ExtendS8Int64,
    ExtendS16Int64,
    ExtendS32Int64,
    AddInt32,
    SubInt32,
    MulInt32,
    DivSInt32,
    DivUInt32,
    RemSInt32,
    RemUInt32,
    AndInt32,
    OrInt32,
    XorInt32,
    ShlInt32,
    ShrUInt32,
    ShrSInt32,
    RotLInt32,
    RotRInt32,
    EqInt32,
    NeInt32,
    LtSInt32,
    LtUInt32,
    LeSInt32,
    LeUInt32,
    GtSInt32,
    GtUInt32,
    GeSInt32,
    GeUInt32,
    AddInt64,
    SubInt64,
    MulInt64,
    DivSInt64,
    DivUInt64,
    RemSInt64,
    RemUInt64,
    AndInt64,
    OrInt64,
    XorInt64,
    ShlInt64,
    ShrUInt64,
    ShrSInt64,
    RotLInt64,
    RotRInt64,
    EqInt64,
    NeInt64,
    LtSInt64,
    LtUInt64,
    LeSInt64,
    LeUInt64,
    GtSInt64,
    GtUInt64,
    GeSInt64,
    GeUInt64,
    AddFloat32,
    SubFloat32,
    MulFloat32,
    DivFloat32,
    CopySignFloat32,
    MinFloat32,
    MaxFloat32,
    EqFloat32,
    NeFloat32,
    LtFloat32,
    LeFloat32,
    GtFloat32,
    GeFloat32,
    AddFloat64,
    SubFloat64,
    MulFloat64,
    DivFloat64,
    CopySignFloat64,
    MinFloat64,
    MaxFloat64,
    EqFloat64,
    NeFloat64,
    LtFloat64,
    LeFloat64,
    GtFloat64,
    GeFloat64,
    AtomicRMWAdd,
    AtomicRMWSub,
    AtomicRMWAnd,
    AtomicRMWOr,
    AtomicRMWXor,
    AtomicRMWXchg,
    SplatVecI8x16,
    ExtractLaneSVecI8x16,
    ExtractLaneUVecI8x16,
    ReplaceLaneVecI8x16,
    SplatVecI16x8,
    ExtractLaneSVecI16x8,
    ExtractLaneUVecI16x8,
    ReplaceLaneVecI16x8,
    SplatVecI32x4,
    ExtractLaneVecI32x4,
    ReplaceLaneVecI32x4,
    SplatVecI64x2,
    ExtractLaneVecI64x2,
    ReplaceLaneVecI64x2,
    SplatVecF32x4,
    ExtractLaneVecF32x4,
    ReplaceLaneVecF32x4,
    SplatVecF64x2,
    ExtractLaneVecF64x2,
    ReplaceLaneVecF64x2,
    EqVecI8x16,
    NeVecI8x16,
    LtSVecI8x16,
    LtUVecI8x16,
    GtSVecI8x16,
    GtUVecI8x16,
    LeSVecI8x16,
    LeUVecI8x16,
    GeSVecI8x16,
    GeUVecI8x16,
    EqVecI16x8,
    NeVecI16x8,
    LtSVecI16x8,
    LtUVecI16x8,
    GtSVecI16x8,
    GtUVecI16x8,
    LeSVecI16x8,
    LeUVecI16x8,
    GeSVecI16x8,
    GeUVecI16x8,
    EqVecI32x4,
    NeVecI32x4,
    LtSVecI32x4,
    LtUVecI32x4,
    GtSVecI32x4,
    GtUVecI32x4,
    LeSVecI32x4,
    LeUVecI32x4,
    GeSVecI32x4,
    GeUVecI32x4,
    EqVecI64x2,
    NeVecI64x2,
    LtSVecI64x2,
    GtSVecI64x2,
    LeSVecI64x2,
    GeSVecI64x2,
    EqVecF32x4,
    NeVecF32x4,
    LtVecF32x4,
    GtVecF32x4,
    LeVecF32x4,
    GeVecF32x4,
    EqVecF64x2,
    NeVecF64x2,
    LtVecF64x2,
    GtVecF64x2,
    LeVecF64x2,
    GeVecF64x2,
    NotVec128,
    AndVec128,
    OrVec128,
    XorVec128,
    AndNotVec128,
    BitselectVec128,
    AnyTrueVec128,
    PopcntVecI8x16,
    AbsVecI8x16,
    NegVecI8x16,
    AllTrueVecI8x16,
    BitmaskVecI8x16,
    ShlVecI8x16,
    ShrSVecI8x16,
    ShrUVecI8x16,
    AddVecI8x16,
    AddSatSVecI8x16,
    AddSatUVecI8x16,
    SubVecI8x16,
    SubSatSVecI8x16,
    SubSatUVecI8x16,
    MinSVecI8x16,
    MinUVecI8x16,
    MaxSVecI8x16,
    MaxUVecI8x16,
    AvgrUVecI8x16,
    AbsVecI16x8,
    NegVecI16x8,
    AllTrueVecI16x8,
    BitmaskVecI16x8,
    ShlVecI16x8,
    ShrSVecI16x8,
    ShrUVecI16x8,
    AddVecI16x8,
    AddSatSVecI16x8,
    AddSatUVecI16x8,
    SubVecI16x8,
    SubSatSVecI16x8,
    SubSatUVecI16x8,
    MulVecI16x8,
    MinSVecI16x8,
    MinUVecI16x8,
    MaxSVecI16x8,
    MaxUVecI16x8,
    AvgrUVecI16x8,
    Q15MulrSatSVecI16x8,
    ExtMulLowSVecI16x8,
    ExtMulHighSVecI16x8,
    ExtMulLowUVecI16x8,
    ExtMulHighUVecI16x8,
    DotSVecI16x8ToVecI32x4,
    ExtMulLowSVecI32x4,
    ExtMulHighSVecI32x4,
    ExtMulLowUVecI32x4,
    ExtMulHighUVecI32x4,
    AbsVecI32x4,
    NegVecI32x4,
    AllTrueVecI32x4,
    BitmaskVecI32x4,
    ShlVecI32x4,
    ShrSVecI32x4,
    ShrUVecI32x4,
    AddVecI32x4,
    SubVecI32x4,
    MulVecI32x4,
    MinSVecI32x4,
    MinUVecI32x4,
    MaxSVecI32x4,
    MaxUVecI32x4,
    AbsVecI64x2,
    NegVecI64x2,
    AllTrueVecI64x2,
    BitmaskVecI64x2,
    ShlVecI64x2,
    ShrSVecI64x2,
    ShrUVecI64x2,
    AddVecI64x2,
    SubVecI64x2,
    MulVecI64x2,
    ExtMulLowSVecI64x2,
    ExtMulHighSVecI64x2,
    ExtMulLowUVecI64x2,
    ExtMulHighUVecI64x2,
    AbsVecF32x4,
    NegVecF32x4,
    SqrtVecF32x4,
    AddVecF32x4,
    SubVecF32x4,
    MulVecF32x4,
    DivVecF32x4,
    MinVecF32x4,
    MaxVecF32x4,
    PMinVecF32x4,
    PMaxVecF32x4,
    CeilVecF32x4,
    FloorVecF32x4,
    TruncVecF32x4,
    NearestVecF32x4,
    AbsVecF64x2,
    NegVecF64x2,
    SqrtVecF64x2,
    AddVecF64x2,
    SubVecF64x2,
    MulVecF64x2,
    DivVecF64x2,
    MinVecF64x2,
    MaxVecF64x2,
    PMinVecF64x2,
    PMaxVecF64x2,
    CeilVecF64x2,
    FloorVecF64x2,
    TruncVecF64x2,
    NearestVecF64x2,
    ExtAddPairwiseSVecI8x16ToI16x8,
    ExtAddPairwiseUVecI8x16ToI16x8,
    ExtAddPairwiseSVecI16x8ToI32x4,
    ExtAddPairwiseUVecI16x8ToI32x4,
    TruncSatSVecF32x4ToVecI32x4,
    TruncSatUVecF32x4ToVecI32x4,
    ConvertSVecI32x4ToVecF32x4,
    ConvertUVecI32x4ToVecF32x4,
    Load8SplatVec128,
    Load16SplatVec128,
    Load32SplatVec128,
    Load64SplatVec128,
    Load8x8SVec128,
    Load8x8UVec128,
    Load16x4SVec128,
    Load16x4UVec128,
    Load32x2SVec128,
    Load32x2UVec128,
    Load32ZeroVec128,
    Load64ZeroVec128,
    Load8LaneVec128,
    Load16LaneVec128,
    Load32LaneVec128,
    Load64LaneVec128,
    Store8LaneVec128,
    Store16LaneVec128,
    Store32LaneVec128,
    Store64LaneVec128,
    NarrowSVecI16x8ToVecI8x16,
    NarrowUVecI16x8ToVecI8x16,
    NarrowSVecI32x4ToVecI16x8,
    NarrowUVecI32x4ToVecI16x8,
    ExtendLowSVecI8x16ToVecI16x8,
    ExtendHighSVecI8x16ToVecI16x8,
    ExtendLowUVecI8x16ToVecI16x8,
    ExtendHighUVecI8x16ToVecI16x8,
    ExtendLowSVecI16x8ToVecI32x4,
    ExtendHighSVecI16x8ToVecI32x4,
    ExtendLowUVecI16x8ToVecI32x4,
    ExtendHighUVecI16x8ToVecI32x4,
    ExtendLowSVecI32x4ToVecI64x2,
    ExtendHighSVecI32x4ToVecI64x2,
    ExtendLowUVecI32x4ToVecI64x2,
    ExtendHighUVecI32x4ToVecI64x2,
    ConvertLowSVecI32x4ToVecF64x2,
    ConvertLowUVecI32x4ToVecF64x2,
    TruncSatZeroSVecF64x2ToVecI32x4,
    TruncSatZeroUVecF64x2ToVecI32x4,
    DemoteZeroVecF64x2ToVecF32x4,
    PromoteLowVecF32x4ToVecF64x2,
    SwizzleVec8x16,
    RefIsNull,
    RefIsFunc,
    RefIsData,
    RefIsI31,
    RefAsNonNull,
    RefAsFunc,
    RefAsData,
    RefAsI31
  }

  const ClzInt32: Operations;
  const CtzInt32: Operations;
  const PopcntInt32: Operations;
  const NegFloat32: Operations;
  const AbsFloat32: Operations;
  const CeilFloat32: Operations;
  const FloorFloat32: Operations;
  const TruncFloat32: Operations;
  const NearestFloat32: Operations;
  const SqrtFloat32: Operations;
  const EqZInt32: Operations;
  const ClzInt64: Operations;
  const CtzInt64: Operations;
  const PopcntInt64: Operations;
  const NegFloat64: Operations;
  const AbsFloat64: Operations;
  const CeilFloat64: Operations;
  const FloorFloat64: Operations;
  const TruncFloat64: Operations;
  const NearestFloat64: Operations;
  const SqrtFloat64: Operations;
  const EqZInt64: Operations;
  const ExtendSInt32: Operations;
  const ExtendUInt32: Operations;
  const WrapInt64: Operations;
  const TruncSFloat32ToInt32: Operations;
  const TruncSFloat32ToInt64: Operations;
  const TruncUFloat32ToInt32: Operations;
  const TruncUFloat32ToInt64: Operations;
  const TruncSFloat64ToInt32: Operations;
  const TruncSFloat64ToInt64: Operations;
  const TruncUFloat64ToInt32: Operations;
  const TruncUFloat64ToInt64: Operations;
  const TruncSatSFloat32ToInt32: Operations;
  const TruncSatSFloat32ToInt64: Operations;
  const TruncSatUFloat32ToInt32: Operations;
  const TruncSatUFloat32ToInt64: Operations;
  const TruncSatSFloat64ToInt32: Operations;
  const TruncSatSFloat64ToInt64: Operations;
  const TruncSatUFloat64ToInt32: Operations;
  const TruncSatUFloat64ToInt64: Operations;
  const ReinterpretFloat32: Operations;
  const ReinterpretFloat64: Operations;
  const ConvertSInt32ToFloat32: Operations;
  const ConvertSInt32ToFloat64: Operations;
  const ConvertUInt32ToFloat32: Operations;
  const ConvertUInt32ToFloat64: Operations;
  const ConvertSInt64ToFloat32: Operations;
  const ConvertSInt64ToFloat64: Operations;
  const ConvertUInt64ToFloat32: Operations;
  const ConvertUInt64ToFloat64: Operations;
  const PromoteFloat32: Operations;
  const DemoteFloat64: Operations;
  const ReinterpretInt32: Operations;
  const ReinterpretInt64: Operations;
  const ExtendS8Int32: Operations;
  const ExtendS16Int32: Operations;
  const ExtendS8Int64: Operations;
  const ExtendS16Int64: Operations;
  const ExtendS32Int64: Operations;
  const AddInt32: Operations;
  const SubInt32: Operations;
  const MulInt32: Operations;
  const DivSInt32: Operations;
  const DivUInt32: Operations;
  const RemSInt32: Operations;
  const RemUInt32: Operations;
  const AndInt32: Operations;
  const OrInt32: Operations;
  const XorInt32: Operations;
  const ShlInt32: Operations;
  const ShrUInt32: Operations;
  const ShrSInt32: Operations;
  const RotLInt32: Operations;
  const RotRInt32: Operations;
  const EqInt32: Operations;
  const NeInt32: Operations;
  const LtSInt32: Operations;
  const LtUInt32: Operations;
  const LeSInt32: Operations;
  const LeUInt32: Operations;
  const GtSInt32: Operations;
  const GtUInt32: Operations;
  const GeSInt32: Operations;
  const GeUInt32: Operations;
  const AddInt64: Operations;
  const SubInt64: Operations;
  const MulInt64: Operations;
  const DivSInt64: Operations;
  const DivUInt64: Operations;
  const RemSInt64: Operations;
  const RemUInt64: Operations;
  const AndInt64: Operations;
  const OrInt64: Operations;
  const XorInt64: Operations;
  const ShlInt64: Operations;
  const ShrUInt64: Operations;
  const ShrSInt64: Operations;
  const RotLInt64: Operations;
  const RotRInt64: Operations;
  const EqInt64: Operations;
  const NeInt64: Operations;
  const LtSInt64: Operations;
  const LtUInt64: Operations;
  const LeSInt64: Operations;
  const LeUInt64: Operations;
  const GtSInt64: Operations;
  const GtUInt64: Operations;
  const GeSInt64: Operations;
  const GeUInt64: Operations;
  const AddFloat32: Operations;
  const SubFloat32: Operations;
  const MulFloat32: Operations;
  const DivFloat32: Operations;
  const CopySignFloat32: Operations;
  const MinFloat32: Operations;
  const MaxFloat32: Operations;
  const EqFloat32: Operations;
  const NeFloat32: Operations;
  const LtFloat32: Operations;
  const LeFloat32: Operations;
  const GtFloat32: Operations;
  const GeFloat32: Operations;
  const AddFloat64: Operations;
  const SubFloat64: Operations;
  const MulFloat64: Operations;
  const DivFloat64: Operations;
  const CopySignFloat64: Operations;
  const MinFloat64: Operations;
  const MaxFloat64: Operations;
  const EqFloat64: Operations;
  const NeFloat64: Operations;
  const LtFloat64: Operations;
  const LeFloat64: Operations;
  const GtFloat64: Operations;
  const GeFloat64: Operations;
  const AtomicRMWAdd: Operations;
  const AtomicRMWSub: Operations;
  const AtomicRMWAnd: Operations;
  const AtomicRMWOr: Operations;
  const AtomicRMWXor: Operations;
  const AtomicRMWXchg: Operations;
  const SplatVecI8x16: Operations;
  const ExtractLaneSVecI8x16: Operations;
  const ExtractLaneUVecI8x16: Operations;
  const ReplaceLaneVecI8x16: Operations;
  const SplatVecI16x8: Operations;
  const ExtractLaneSVecI16x8: Operations;
  const ExtractLaneUVecI16x8: Operations;
  const ReplaceLaneVecI16x8: Operations;
  const SplatVecI32x4: Operations;
  const ExtractLaneVecI32x4: Operations;
  const ReplaceLaneVecI32x4: Operations;
  const SplatVecI64x2: Operations;
  const ExtractLaneVecI64x2: Operations;
  const ReplaceLaneVecI64x2: Operations;
  const SplatVecF32x4: Operations;
  const ExtractLaneVecF32x4: Operations;
  const ReplaceLaneVecF32x4: Operations;
  const SplatVecF64x2: Operations;
  const ExtractLaneVecF64x2: Operations;
  const ReplaceLaneVecF64x2: Operations;
  const EqVecI8x16: Operations;
  const NeVecI8x16: Operations;
  const LtSVecI8x16: Operations;
  const LtUVecI8x16: Operations;
  const GtSVecI8x16: Operations;
  const GtUVecI8x16: Operations;
  const LeSVecI8x16: Operations;
  const LeUVecI8x16: Operations;
  const GeSVecI8x16: Operations;
  const GeUVecI8x16: Operations;
  const EqVecI16x8: Operations;
  const NeVecI16x8: Operations;
  const LtSVecI16x8: Operations;
  const LtUVecI16x8: Operations;
  const GtSVecI16x8: Operations;
  const GtUVecI16x8: Operations;
  const LeSVecI16x8: Operations;
  const LeUVecI16x8: Operations;
  const GeSVecI16x8: Operations;
  const GeUVecI16x8: Operations;
  const EqVecI32x4: Operations;
  const NeVecI32x4: Operations;
  const LtSVecI32x4: Operations;
  const LtUVecI32x4: Operations;
  const GtSVecI32x4: Operations;
  const GtUVecI32x4: Operations;
  const LeSVecI32x4: Operations;
  const LeUVecI32x4: Operations;
  const GeSVecI32x4: Operations;
  const GeUVecI32x4: Operations;
  const EqVecI64x2: Operations;
  const NeVecI64x2: Operations;
  const LtSVecI64x2: Operations;
  const GtSVecI64x2: Operations;
  const LeSVecI64x2: Operations;
  const GeSVecI64x2: Operations;
  const EqVecF32x4: Operations;
  const NeVecF32x4: Operations;
  const LtVecF32x4: Operations;
  const GtVecF32x4: Operations;
  const LeVecF32x4: Operations;
  const GeVecF32x4: Operations;
  const EqVecF64x2: Operations;
  const NeVecF64x2: Operations;
  const LtVecF64x2: Operations;
  const GtVecF64x2: Operations;
  const LeVecF64x2: Operations;
  const GeVecF64x2: Operations;
  const NotVec128: Operations;
  const AndVec128: Operations;
  const OrVec128: Operations;
  const XorVec128: Operations;
  const AndNotVec128: Operations;
  const BitselectVec128: Operations;
  const AnyTrueVec128: Operations;
  const PopcntVecI8x16: Operations;
  const AbsVecI8x16: Operations;
  const NegVecI8x16: Operations;
  const AllTrueVecI8x16: Operations;
  const BitmaskVecI8x16: Operations;
  const ShlVecI8x16: Operations;
  const ShrSVecI8x16: Operations;
  const ShrUVecI8x16: Operations;
  const AddVecI8x16: Operations;
  const AddSatSVecI8x16: Operations;
  const AddSatUVecI8x16: Operations;
  const SubVecI8x16: Operations;
  const SubSatSVecI8x16: Operations;
  const SubSatUVecI8x16: Operations;
  const MinSVecI8x16: Operations;
  const MinUVecI8x16: Operations;
  const MaxSVecI8x16: Operations;
  const MaxUVecI8x16: Operations;
  const AvgrUVecI8x16: Operations;
  const AbsVecI16x8: Operations;
  const NegVecI16x8: Operations;
  const AllTrueVecI16x8: Operations;
  const BitmaskVecI16x8: Operations;
  const ShlVecI16x8: Operations;
  const ShrSVecI16x8: Operations;
  const ShrUVecI16x8: Operations;
  const AddVecI16x8: Operations;
  const AddSatSVecI16x8: Operations;
  const AddSatUVecI16x8: Operations;
  const SubVecI16x8: Operations;
  const SubSatSVecI16x8: Operations;
  const SubSatUVecI16x8: Operations;
  const MulVecI16x8: Operations;
  const MinSVecI16x8: Operations;
  const MinUVecI16x8: Operations;
  const MaxSVecI16x8: Operations;
  const MaxUVecI16x8: Operations;
  const AvgrUVecI16x8: Operations;
  const Q15MulrSatSVecI16x8: Operations;
  const ExtMulLowSVecI16x8: Operations;
  const ExtMulHighSVecI16x8: Operations;
  const ExtMulLowUVecI16x8: Operations;
  const ExtMulHighUVecI16x8: Operations;
  const DotSVecI16x8ToVecI32x4: Operations;
  const ExtMulLowSVecI32x4: Operations;
  const ExtMulHighSVecI32x4: Operations;
  const ExtMulLowUVecI32x4: Operations;
  const ExtMulHighUVecI32x4: Operations;
  const AbsVecI32x4: Operations;
  const NegVecI32x4: Operations;
  const AllTrueVecI32x4: Operations;
  const BitmaskVecI32x4: Operations;
  const ShlVecI32x4: Operations;
  const ShrSVecI32x4: Operations;
  const ShrUVecI32x4: Operations;
  const AddVecI32x4: Operations;
  const SubVecI32x4: Operations;
  const MulVecI32x4: Operations;
  const MinSVecI32x4: Operations;
  const MinUVecI32x4: Operations;
  const MaxSVecI32x4: Operations;
  const MaxUVecI32x4: Operations;
  const AbsVecI64x2: Operations;
  const NegVecI64x2: Operations;
  const AllTrueVecI64x2: Operations;
  const BitmaskVecI64x2: Operations;
  const ShlVecI64x2: Operations;
  const ShrSVecI64x2: Operations;
  const ShrUVecI64x2: Operations;
  const AddVecI64x2: Operations;
  const SubVecI64x2: Operations;
  const MulVecI64x2: Operations;
  const ExtMulLowSVecI64x2: Operations;
  const ExtMulHighSVecI64x2: Operations;
  const ExtMulLowUVecI64x2: Operations;
  const ExtMulHighUVecI64x2: Operations;
  const AbsVecF32x4: Operations;
  const NegVecF32x4: Operations;
  const SqrtVecF32x4: Operations;
  const AddVecF32x4: Operations;
  const SubVecF32x4: Operations;
  const MulVecF32x4: Operations;
  const DivVecF32x4: Operations;
  const MinVecF32x4: Operations;
  const MaxVecF32x4: Operations;
  const PMinVecF32x4: Operations;
  const PMaxVecF32x4: Operations;
  const CeilVecF32x4: Operations;
  const FloorVecF32x4: Operations;
  const TruncVecF32x4: Operations;
  const NearestVecF32x4: Operations;
  const AbsVecF64x2: Operations;
  const NegVecF64x2: Operations;
  const SqrtVecF64x2: Operations;
  const AddVecF64x2: Operations;
  const SubVecF64x2: Operations;
  const MulVecF64x2: Operations;
  const DivVecF64x2: Operations;
  const MinVecF64x2: Operations;
  const MaxVecF64x2: Operations;
  const PMinVecF64x2: Operations;
  const PMaxVecF64x2: Operations;
  const CeilVecF64x2: Operations;
  const FloorVecF64x2: Operations;
  const TruncVecF64x2: Operations;
  const NearestVecF64x2: Operations;
  const ExtAddPairwiseSVecI8x16ToI16x8: Operations;
  const ExtAddPairwiseUVecI8x16ToI16x8: Operations;
  const ExtAddPairwiseSVecI16x8ToI32x4: Operations;
  const ExtAddPairwiseUVecI16x8ToI32x4: Operations;
  const TruncSatSVecF32x4ToVecI32x4: Operations;
  const TruncSatUVecF32x4ToVecI32x4: Operations;
  const ConvertSVecI32x4ToVecF32x4: Operations;
  const ConvertUVecI32x4ToVecF32x4: Operations;
  const Load8SplatVec128: Operations;
  const Load16SplatVec128: Operations;
  const Load32SplatVec128: Operations;
  const Load64SplatVec128: Operations;
  const Load8x8SVec128: Operations;
  const Load8x8UVec128: Operations;
  const Load16x4SVec128: Operations;
  const Load16x4UVec128: Operations;
  const Load32x2SVec128: Operations;
  const Load32x2UVec128: Operations;
  const Load32ZeroVec128: Operations;
  const Load64ZeroVec128: Operations;
  const Load8LaneVec128: Operations;
  const Load16LaneVec128: Operations;
  const Load32LaneVec128: Operations;
  const Load64LaneVec128: Operations;
  const Store8LaneVec128: Operations;
  const Store16LaneVec128: Operations;
  const Store32LaneVec128: Operations;
  const Store64LaneVec128: Operations;
  const NarrowSVecI16x8ToVecI8x16: Operations;
  const NarrowUVecI16x8ToVecI8x16: Operations;
  const NarrowSVecI32x4ToVecI16x8: Operations;
  const NarrowUVecI32x4ToVecI16x8: Operations;
  const ExtendLowSVecI8x16ToVecI16x8: Operations;
  const ExtendHighSVecI8x16ToVecI16x8: Operations;
  const ExtendLowUVecI8x16ToVecI16x8: Operations;
  const ExtendHighUVecI8x16ToVecI16x8: Operations;
  const ExtendLowSVecI16x8ToVecI32x4: Operations;
  const ExtendHighSVecI16x8ToVecI32x4: Operations;
  const ExtendLowUVecI16x8ToVecI32x4: Operations;
  const ExtendHighUVecI16x8ToVecI32x4: Operations;
  const ExtendLowSVecI32x4ToVecI64x2: Operations;
  const ExtendHighSVecI32x4ToVecI64x2: Operations;
  const ExtendLowUVecI32x4ToVecI64x2: Operations;
  const ExtendHighUVecI32x4ToVecI64x2: Operations;
  const ConvertLowSVecI32x4ToVecF64x2: Operations;
  const ConvertLowUVecI32x4ToVecF64x2: Operations;
  const TruncSatZeroSVecF64x2ToVecI32x4: Operations;
  const TruncSatZeroUVecF64x2ToVecI32x4: Operations;
  const DemoteZeroVecF64x2ToVecF32x4: Operations;
  const PromoteLowVecF32x4ToVecF64x2: Operations;
  const SwizzleVec8x16: Operations;
  const RefIsNull: Operations;
  const RefIsFunc: Operations;
  const RefIsData: Operations;
  const RefIsI31: Operations;
  const RefAsNonNull: Operations;
  const RefAsFunc: Operations;
  const RefAsData: Operations;
  const RefAsI31: Operations;

  const enum ExpressionRunnerFlags {
    Default,
    PreserveSideeffects,
    TraverseCalls
  }

  type ElementSegmentRef = number;
  type ExpressionRef = number;
  type FunctionRef = number;
  type GlobalRef = number;
  type ExportRef = number;
  type TableRef = number;
  type TagRef = number;

  class Module {
    constructor();
    readonly ptr: number;
    block(label: string | null, children: ExpressionRef[], resultType?: Type): ExpressionRef;
    if(condition: ExpressionRef, ifTrue: ExpressionRef, ifFalse?: ExpressionRef): ExpressionRef;
    loop(label: string | null, body: ExpressionRef): ExpressionRef;
    br(label: string, condition?: ExpressionRef, value?: ExpressionRef): ExpressionRef;
    br_if(label: string, condition?: ExpressionRef, value?: ExpressionRef): ExpressionRef;
    switch(labels: string[], defaultLabel: string, condition: ExpressionRef, value?: ExpressionRef): ExpressionRef;
    call(name: string, operands: ExpressionRef[], returnType: Type): ExpressionRef;
    return_call(name: string, operands: ExpressionRef[], returnType: Type): ExpressionRef;
    call_indirect(target: ExpressionRef, operands: ExpressionRef[], params: Type, results: Type): ExpressionRef;
    return_call_indirect(target: ExpressionRef, operands: ExpressionRef[], params: Type, results: Type): ExpressionRef;
    local: {
      get(index: number, type: Type): ExpressionRef;
      set(index: number, value: ExpressionRef): ExpressionRef;
      tee(index: number, value: ExpressionRef, type: Type): ExpressionRef;
    };
    global: {
      get(name: string, type: Type): ExpressionRef;
      set(name: string, value: ExpressionRef): ExpressionRef;
    };
    table: {
      get(name: string, index: ExpressionRef, type: Type): ExpressionRef;
      set(name: string, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      size(name: string): ExpressionRef;
      grow(name: string, value: ExpressionRef, delta: ExpressionRef): ExpressionRef;
      // TODO: init, fill, copy
    };
    memory: {
      size(): ExpressionRef;
      grow(value: ExpressionRef): ExpressionRef;
      init(segment: number, dest: ExpressionRef, offset: ExpressionRef, size: ExpressionRef): ExpressionRef;
      copy(dest: ExpressionRef, source: ExpressionRef, size: ExpressionRef): ExpressionRef;
      fill(dest: ExpressionRef, value: ExpressionRef, size: ExpressionRef): ExpressionRef;
      atomic: {
        notify(ptr: ExpressionRef, notifyCount: ExpressionRef): ExpressionRef;
        wait32(ptr: ExpressionRef, expected: ExpressionRef, timeout: ExpressionRef): ExpressionRef;
        wait64(ptr: ExpressionRef, expected: ExpressionRef, timeout: ExpressionRef): ExpressionRef;
      }
    };
    data: {
      drop(segment: number): ExpressionRef;
    };
    i32: {
      load(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      store(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      store8(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      store16(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      const(value: number): ExpressionRef;
      clz(value: ExpressionRef): ExpressionRef;
      ctz(value: ExpressionRef): ExpressionRef;
      popcnt(value: ExpressionRef): ExpressionRef;
      eqz(value: ExpressionRef): ExpressionRef;
      trunc_s: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      trunc_u: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      trunc_s_sat: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      trunc_u_sat: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      reinterpret(value: ExpressionRef): ExpressionRef;
      extend8_s(value: ExpressionRef): ExpressionRef;
      extend16_s(value: ExpressionRef): ExpressionRef;
      wrap(value: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rem_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rem_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      and(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      or(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      xor(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      shl(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      shr_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      shr_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rotl(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rotr(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      atomic: {
        load(offset: number, ptr: ExpressionRef): ExpressionRef;
        load8_u(offset: number, ptr: ExpressionRef): ExpressionRef;
        load16_u(offset: number, ptr: ExpressionRef): ExpressionRef;
        store(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        store8(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        store16(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        rmw: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
        rmw8_u: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
        rmw16_u: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
      },
      pop(): ExpressionRef;
    };
    i64: {
      load(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load32_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load32_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      store(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      store8(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      store16(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      store32(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      const(low: number, high: number): ExpressionRef;
      clz(value: ExpressionRef): ExpressionRef;
      ctz(value: ExpressionRef): ExpressionRef;
      popcnt(value: ExpressionRef): ExpressionRef;
      eqz(value: ExpressionRef): ExpressionRef;
      trunc_s: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      trunc_u: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      trunc_s_sat: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      trunc_u_sat: {
        f32(value: ExpressionRef): ExpressionRef;
        f64(value: ExpressionRef): ExpressionRef;
      };
      reinterpret(value: ExpressionRef): ExpressionRef;
      extend8_s(value: ExpressionRef): ExpressionRef;
      extend16_s(value: ExpressionRef): ExpressionRef;
      extend32_s(value: ExpressionRef): ExpressionRef;
      extend_s(value: ExpressionRef): ExpressionRef;
      extend_u(value: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rem_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rem_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      and(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      or(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      xor(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      shl(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      shr_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      shr_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rotl(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      rotr(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      atomic: {
        load(offset: number, ptr: ExpressionRef): ExpressionRef;
        load8_u(offset: number, ptr: ExpressionRef): ExpressionRef;
        load16_u(offset: number, ptr: ExpressionRef): ExpressionRef;
        load32_u(offset: number, ptr: ExpressionRef): ExpressionRef;
        store(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        store8(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        store16(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        store32(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
        rmw: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
        rmw8_u: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
        rmw16_u: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
        rmw32_u: {
          add(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          sub(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          and(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          or(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xor(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          xchg(offset: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
          cmpxchg(offset: number, ptr: ExpressionRef, expected: ExpressionRef, replacement: ExpressionRef): ExpressionRef;
        },
      },
      pop(): ExpressionRef;
    };
    f32: {
      load(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      store(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      const(value: number): ExpressionRef;
      const_bits(value: number): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      ceil(value: ExpressionRef): ExpressionRef;
      floor(value: ExpressionRef): ExpressionRef;
      trunc(value: ExpressionRef): ExpressionRef;
      nearest(value: ExpressionRef): ExpressionRef;
      sqrt(value: ExpressionRef): ExpressionRef;
      reinterpret(value: ExpressionRef): ExpressionRef;
      convert_s: {
        i32(value: ExpressionRef): ExpressionRef;
        i64(value: ExpressionRef): ExpressionRef;
      };
      convert_u: {
        i32(value: ExpressionRef): ExpressionRef;
        i64(value: ExpressionRef): ExpressionRef;
      };
      demote(value: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      copysign(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      pop(): ExpressionRef;
    };
    f64: {
      load(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      store(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      const(value: number): ExpressionRef;
      const_bits(low: number, high: number): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      ceil(value: ExpressionRef): ExpressionRef;
      floor(value: ExpressionRef): ExpressionRef;
      trunc(value: ExpressionRef): ExpressionRef;
      nearest(value: ExpressionRef): ExpressionRef;
      sqrt(value: ExpressionRef): ExpressionRef;
      reinterpret(value: ExpressionRef): ExpressionRef;
      convert_s: {
        i32(value: ExpressionRef): ExpressionRef;
        i64(value: ExpressionRef): ExpressionRef;
      };
      convert_u: {
        i32(value: ExpressionRef): ExpressionRef;
        i64(value: ExpressionRef): ExpressionRef;
      };
      promote(value: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      copysign(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      pop(): ExpressionRef;
    };
    v128: {
      load(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8_splat(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16_splat(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load32_splat(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load64_splat(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8x8_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8x8_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16x4_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load16x4_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load32x2_s(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load32x2_u(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load32_zero(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load64_zero(offset: number, align: number, ptr: ExpressionRef): ExpressionRef;
      load8_lane(offset: number, align: number, index: number, ptr: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      load16_lane(offset: number, align: number, index: number, ptr: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      load32_lane(offset: number, align: number, index: number, ptr: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      load64_lane(offset: number, align: number, index: number, ptr: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      store8_lane(offset: number, align: number, index: number, pt: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      store16_lane(offset: number, align: number, index: number, pt: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      store32_lane(offset: number, align: number, index: number, pt: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      store64_lane(offset: number, align: number, index: number, pt: ExpressionRef, vec: ExpressionRef): ExpressionRef;
      store(offset: number, align: number, ptr: ExpressionRef, value: ExpressionRef): ExpressionRef;
      const(value: ArrayLike<number>): ExpressionRef;
      not(value: ExpressionRef): ExpressionRef;
      any_true(value: ExpressionRef): ExpressionRef;
      and(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      or(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      xor(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      andnot(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      bitselect(left: ExpressionRef, right: ExpressionRef, cond: ExpressionRef): ExpressionRef;
      pop(): ExpressionRef;
    };
    i8x16: {
      shuffle(left: ExpressionRef, right: ExpressionRef, mask: ArrayLike<number>): ExpressionRef;
      swizzle(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      splat(value: ExpressionRef): ExpressionRef;
      extract_lane_s(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      extract_lane_u(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      replace_lane(vec: ExpressionRef, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      all_true(value: ExpressionRef): ExpressionRef;
      bitmask(value: ExpressionRef): ExpressionRef;
      popcnt(value: ExpressionRef): ExpressionRef;
      shl(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_s(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_u(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      add_saturate_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      add_saturate_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub_saturate_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub_saturate_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      avgr_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      narrow_i16x8_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      narrow_i16x8_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
    };
    i16x8: {
      splat(value: ExpressionRef): ExpressionRef;
      extract_lane_s(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      extract_lane_u(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      replace_lane(vec: ExpressionRef, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      all_true(value: ExpressionRef): ExpressionRef;
      bitmask(value: ExpressionRef): ExpressionRef;
      shl(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_s(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_u(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      add_saturate_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      add_saturate_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub_saturate_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub_saturate_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      avgr_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      q15mulr_sat_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_low_i8x16_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_high_i8x16_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_low_i8x16_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_high_i8x16_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extadd_pairwise_i8x16_s(value: ExpressionRef): ExpressionRef;
      extadd_pairwise_i8x16_u(value: ExpressionRef): ExpressionRef;
      narrow_i32x4_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      narrow_i32x4_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extend_low_i8x16_s(value: ExpressionRef): ExpressionRef;
      extend_high_i8x16_s(value: ExpressionRef): ExpressionRef;
      extend_low_i8x16_u(value: ExpressionRef): ExpressionRef;
      extend_high_i8x16_u(value: ExpressionRef): ExpressionRef;
    };
    i32x4: {
      splat(value: ExpressionRef): ExpressionRef;
      extract_lane(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      replace_lane(vec: ExpressionRef, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      all_true(value: ExpressionRef): ExpressionRef;
      bitmask(value: ExpressionRef): ExpressionRef;
      shl(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_s(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_u(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      dot_i16x8_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_low_i16x8_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_high_i16x8_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_low_i16x8_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_high_i16x8_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extadd_pairwise_i16x8_s(value: ExpressionRef): ExpressionRef;
      extadd_pairwise_i16x8_u(value: ExpressionRef): ExpressionRef;
      trunc_sat_f32x4_s(value: ExpressionRef): ExpressionRef;
      trunc_sat_f32x4_u(value: ExpressionRef): ExpressionRef;
      extend_low_i16x8_s(value: ExpressionRef): ExpressionRef;
      extend_high_i16x8_s(value: ExpressionRef): ExpressionRef;
      extend_low_i16x8_u(value: ExpressionRef): ExpressionRef;
      extend_high_i16x8_u(value: ExpressionRef): ExpressionRef;
      trunc_sat_f64x2_s_zero(value: ExpressionRef): ExpressionRef;
      trunc_sat_f64x2_u_zero(value: ExpressionRef): ExpressionRef;
    };
    i64x2: {
      splat(value: ExpressionRef): ExpressionRef;
      extract_lane(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      replace_lane(vec: ExpressionRef, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      all_true(value: ExpressionRef): ExpressionRef;
      bitmask(value: ExpressionRef): ExpressionRef;
      shl(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_s(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      shr_u(vec: ExpressionRef, shift: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_low_i32x4_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_high_i32x4_s(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_low_i32x4_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extmul_high_i32x4_u(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      extend_low_i32x4_s(value: ExpressionRef): ExpressionRef;
      extend_high_i32x4_s(value: ExpressionRef): ExpressionRef;
      extend_low_i32x4_u(value: ExpressionRef): ExpressionRef;
      extend_high_i32x4_u(value: ExpressionRef): ExpressionRef;
    };
    f32x4: {
      splat(value: ExpressionRef): ExpressionRef;
      extract_lane(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      replace_lane(vec: ExpressionRef, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      sqrt(value: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      pmin(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      pmax(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ceil(value: ExpressionRef): ExpressionRef;
      floor(value: ExpressionRef): ExpressionRef;
      trunc(value: ExpressionRef): ExpressionRef;
      nearest(value: ExpressionRef): ExpressionRef;
      convert_i32x4_s(value: ExpressionRef): ExpressionRef;
      convert_i32x4_u(value: ExpressionRef): ExpressionRef;
      demote_f64x2_zero(value: ExpressionRef): ExpressionRef;
    };
    f64x2: {
      splat(value: ExpressionRef): ExpressionRef;
      extract_lane(vec: ExpressionRef, index: ExpressionRef): ExpressionRef;
      replace_lane(vec: ExpressionRef, index: ExpressionRef, value: ExpressionRef): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ne(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      lt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      gt(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      le(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ge(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      abs(value: ExpressionRef): ExpressionRef;
      neg(value: ExpressionRef): ExpressionRef;
      sqrt(value: ExpressionRef): ExpressionRef;
      add(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      sub(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      mul(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      div(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      min(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      max(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      pmin(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      pmax(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
      ceil(value: ExpressionRef): ExpressionRef;
      floor(value: ExpressionRef): ExpressionRef;
      trunc(value: ExpressionRef): ExpressionRef;
      nearest(value: ExpressionRef): ExpressionRef;
      convert_low_i32x4_s(value: ExpressionRef): ExpressionRef;
      convert_low_i32x4_u(value: ExpressionRef): ExpressionRef;
      promote_low_f32x4(value: ExpressionRef): ExpressionRef;
    };
    funcref: {
      pop(): ExpressionRef;
    };
    externref: {
      pop(): ExpressionRef;
    };
    anyref: {
      pop(): ExpressionRef;
    };
    eqref: {
      pop(): ExpressionRef;
    };
    i31ref: {
      pop(): ExpressionRef;
    };
    dataref: {
      pop(): ExpressionRef;
    };
    ref: {
      null(type: Type): ExpressionRef;
      is_null(value: ExpressionRef): ExpressionRef;
      is_func(value: ExpressionRef): ExpressionRef;
      is_data(value: ExpressionRef): ExpressionRef;
      is_i31(value: ExpressionRef): ExpressionRef;
      as_non_null(value: ExpressionRef): ExpressionRef;
      as_func(value: ExpressionRef): ExpressionRef;
      as_data(value: ExpressionRef): ExpressionRef;
      as_i31(value: ExpressionRef): ExpressionRef;
      func(name: string, type: Type): ExpressionRef;
      eq(left: ExpressionRef, right: ExpressionRef): ExpressionRef;
    };
    i31: {
      'new'(value: ExpressionRef): ExpressionRef;
      get_s(i31: ExpressionRef): ExpressionRef;
      get_u(i31: ExpressionRef): ExpressionRef;
    }
    atomic: {
      fence(): ExpressionRef;
    };
    tuple: {
      make(elements: ExportRef[]): ExpressionRef;
      extract(tuple: ExpressionRef, index: number): ExpressionRef;
    };
    try(name: string, body: ExpressionRef, catchTags: string[], catchBodies: ExpressionRef[], delegateTarget?: string): ExpressionRef;
    throw(tag: string, operands: ExpressionRef[]): ExpressionRef;
    rethrow(target: string): ExpressionRef;
    select(condition: ExpressionRef, ifTrue: ExpressionRef, ifFalse: ExpressionRef, type?: Type): ExpressionRef;
    drop(value: ExpressionRef): ExpressionRef;
    return(value?: ExpressionRef): ExpressionRef;
    nop(): ExpressionRef;
    unreachable(): ExpressionRef;
    addFunction(name: string, params: Type, results: Type, vars: Type[], body: ExpressionRef): FunctionRef;
    getFunction(name: string): FunctionRef;
    removeFunction(name: string): void;
    getNumFunctions(): number;
    getFunctionByIndex(index: number): FunctionRef;
    addGlobal(name: string, type: Type, mutable: boolean, init: ExpressionRef): GlobalRef;
    getGlobal(name: string): GlobalRef;
    removeGlobal(name: string): void;
    addTable(name: string, initial: number, maximum: number, type: Type): TableRef;
    getTable(name: string): TableRef;
    removeTable(name: string): void;
    addTag(name: string, params: Type, results: Type): TagRef;
    getTag(name: string): TagRef;
    removeTag(name: string): void;
    addFunctionImport(internalName: string, externalModuleName: string, externalBaseName: string, params: Type, results: Type): void;
    addTableImport(internalName: string, externalModuleName: string, externalBaseName: string): void;
    addMemoryImport(internalName: string, externalModuleName: string, externalBaseName: string): void;
    addGlobalImport(internalName: string, externalModuleName: string, externalBaseName: string, globalType: Type): void;
    addTagImport(internalName: string, externalModuleName: string, externalBaseName: string, params: Type, results: Type): void;
    addFunctionExport(internalName: string, externalName: string): ExportRef;
    addTableExport(internalName: string, externalName: string): ExportRef;
    addMemoryExport(internalName: string, externalName: string): ExportRef;
    addGlobalExport(internalName: string, externalName: string): ExportRef;
    addTagExport(internalName: string, externalName: string): ExportRef;
    removeExport(externalName: string): void;
    getExport(externalName: string): ExportRef;
    getNumExports(): number;
    getExportByIndex(index: number): ExportRef;
    setFunctionTable(initial: number, maximum: number, funcNames: number[], offset?: ExpressionRef): void;
    getFunctionTable(): { imported: boolean, segments: TableElement[] };
    setMemory(initial: number, maximum: number, exportName?: string | null, segments?: MemorySegment[] | null, flags?: number[] | null, shared?: boolean): void;
    getMemorySegmentInfoByIndex(index: number): MemorySegmentInfo;
    setStart(start: FunctionRef): void;
    getFeatures(): Features;
    setFeatures(features: Features): void;
    addCustomSection(name: string, contents: Uint8Array): void;
    getNumGlobals(): number;
    getNumTables(): number;
    getNumMemorySegments(): number;
    getNumElementSegments(): number;
    getGlobalByIndex(index: number): GlobalRef;
    getTableByIndex(index: number): TableRef;
    getElementSegmentByIndex(index: number): ElementSegmentRef;
    emitText(): string;
    emitStackIR(optimize?: boolean): string;
    emitAsmjs(): string;
    validate(): number;
    optimize(): void;
    optimizeFunction(func: string | FunctionRef): void;
    runPasses(passes: string[]): void;
    runPassesOnFunction(func: string | FunctionRef, passes: string[]): void;
    autoDrop(): void;
    dispose(): void;
    emitBinary(): Uint8Array;
    emitBinary(sourceMapUrl: string | null): { binary: Uint8Array; sourceMap: string | null; };
    interpret(): void;
    addDebugInfoFileName(filename: string): number;
    getDebugInfoFileName(index: number): string | null;
    setDebugLocation(func: FunctionRef, expr: ExpressionRef, fileIndex: number, lineNumber: number, columnNumber: number): void;
    copyExpression(expr: ExpressionRef): ExpressionRef;
  }

  interface MemorySegment {
    offset: ExpressionRef;
    data: Uint8Array;
    passive?: boolean;
  }

  interface TableElement {
    offset: ExpressionRef;
    names: string[];
  }

  function wrapModule(ptr: number): Module;

  function getExpressionId(expression: ExpressionRef): number;
  function getExpressionType(expression: ExpressionRef): Type;
  function getExpressionInfo(expression: ExpressionRef): ExpressionInfo;

  interface MemorySegmentInfo {
    offset: ExpressionRef;
    data: Uint8Array;
    passive: boolean;
  }

  interface ExpressionInfo {
    id: ExpressionIds;
    type: Type;
  }

  interface BlockInfo extends ExpressionInfo {
    name: string;
    children: ExpressionRef[];
  }

  interface IfInfo extends ExpressionInfo {
    condition: ExpressionRef;
    ifTrue: ExpressionRef;
    ifFalse: ExpressionRef;
  }

  interface LoopInfo extends ExpressionInfo {
    name: string;
    body: ExpressionRef;
  }

  interface BreakInfo extends ExpressionInfo {
    name: string;
    condition: ExpressionRef;
    value: ExpressionRef;
  }

  interface SwitchInfo extends ExpressionInfo {
    names: string[];
    defaultName: string | null;
    condition: ExpressionRef;
    value: ExpressionRef;
  }

  interface CallInfo extends ExpressionInfo {
    isReturn: boolean;
    target: string;
    operands: ExpressionRef[];
  }

  interface CallIndirectInfo extends ExpressionInfo {
    isReturn: boolean;
    target: ExpressionRef;
    operands: ExpressionRef[];
  }

  interface LocalGetInfo extends ExpressionInfo {
    index: number;
  }

  interface LocalSetInfo extends ExpressionInfo {
    isTee: boolean;
    index: number;
    value: ExpressionRef;
  }

  interface GlobalGetInfo extends ExpressionInfo {
    name: string;
  }

  interface GlobalSetInfo extends ExpressionInfo {
    name: string;
    value: ExpressionRef;
  }

  interface TableGetInfo extends ExpressionInfo {
    table: string;
    index: ExpressionRef;
  }

  interface TableSetInfo extends ExpressionInfo {
    table: string;
    index: ExpressionRef;
    value: ExpressionRef;
  }

  interface TableSizeInfo extends ExpressionInfo {
    table: string;
  }

  interface TableGrowInfo extends ExpressionInfo {
    table: string;
    value: ExpressionRef;
    delta: ExpressionRef;
  }

  interface LoadInfo extends ExpressionInfo {
    isAtomic: boolean;
    isSigned: boolean;
    offset: number;
    bytes: number;
    align: number;
    ptr: ExpressionRef;
  }

  interface StoreInfo extends ExpressionInfo {
    isAtomic: boolean;
    offset: number;
    bytes: number;
    align: number;
    ptr: ExpressionRef;
    value: ExpressionRef;
  }

  interface ConstInfo extends ExpressionInfo {
    value: number | { low: number, high: number } | Array<number>;
  }

  interface UnaryInfo extends ExpressionInfo {
    op: Operations;
    value: ExpressionRef;
  }

  interface BinaryInfo extends ExpressionInfo {
    op: Operations;
    left: ExpressionRef;
    right: ExpressionRef;
  }

  interface SelectInfo extends ExpressionInfo {
    ifTrue: ExpressionRef;
    ifFalse: ExpressionRef;
    condition: ExpressionRef;
  }

  interface DropInfo extends ExpressionInfo {
    value: ExpressionRef;
  }

  interface ReturnInfo extends ExpressionInfo {
    value: ExpressionRef;
  }

  interface NopInfo extends ExpressionInfo {
  }

  interface UnreachableInfo extends ExpressionInfo {
  }

  interface PopInfo extends ExpressionInfo {
  }

  interface MemorySizeInfo extends ExpressionInfo {
  }

  interface MemoryGrowInfo extends ExpressionInfo {
    delta: ExpressionRef;
  }

  interface AtomicRMWInfo extends ExpressionInfo {
    op: Operations;
    bytes: number;
    offset: number;
    ptr: ExpressionRef;
    value: ExpressionRef;
  }

  interface AtomicCmpxchgInfo extends ExpressionInfo {
    bytes: number;
    offset: number;
    ptr: ExpressionRef;
    expected: ExpressionRef;
    replacement: ExpressionRef;
  }

  interface AtomicWaitInfo extends ExpressionInfo {
    ptr: ExpressionRef;
    expected: ExpressionRef;
    timeout: ExpressionRef;
    expectedType: Type;
  }

  interface AtomicNotifyInfo extends ExpressionInfo {
    ptr: ExpressionRef;
    notifyCount: ExpressionRef;
  }

  interface AtomicFenceInfo extends ExpressionInfo {
    order: number;
  }

  interface SIMDExtractInfo extends ExpressionInfo {
    op: Operations;
    vec: ExpressionRef;
    index: ExpressionRef;
  }

  interface SIMDReplaceInfo extends ExpressionInfo {
    op: Operations;
    vec: ExpressionRef;
    index: ExpressionRef;
    value: ExpressionRef;
  }

  interface SIMDShuffleInfo extends ExpressionInfo {
    left: ExpressionRef;
    right: ExpressionRef;
    mask: number[];
  }

  interface SIMDTernaryInfo extends ExpressionInfo {
    op: Operations;
    a: ExpressionRef;
    b: ExpressionRef;
    c: ExpressionRef;
  }

  interface SIMDShiftInfo extends ExpressionInfo {
    op: Operations;
    vec: ExpressionRef;
    shift: ExpressionRef;
  }

  interface SIMDLoadInfo extends ExpressionInfo {
    op: Operations;
    offset: number;
    align: number;
    ptr: ExpressionRef;
  }

  interface SIMDLoadStoreLaneInfo extends ExpressionInfo {
    op: Operations;
    offset: number;
    align: number;
    index: number;
    ptr: ExpressionRef;
    vec: ExpressionRef;
  }

  interface MemoryInitInfo extends ExpressionInfo {
    segment: number;
    dest: ExpressionRef;
    offset: ExpressionRef;
    size: ExpressionRef;
  }

  interface DataDropInfo extends ExpressionInfo {
    segment: number;
  }

  interface MemoryCopyInfo extends ExpressionInfo {
    dest: ExpressionRef;
    source: ExpressionRef;
    size: ExpressionRef;
  }

  interface MemoryFillInfo extends ExpressionInfo {
    dest: ExpressionRef;
    value: ExpressionRef;
    size: ExpressionRef;
  }

  interface RefNullInfo extends ExpressionInfo {
  }

  interface RefIsInfo extends ExpressionInfo {
    op: Operations;
    value: ExpressionRef;
  }

  interface RefAsInfo extends ExpressionInfo {
    op: Operations;
    value: ExpressionRef;
  }

  interface RefFuncInfo extends ExpressionInfo {
    func: string;
  }

  interface RefEqInfo extends ExpressionInfo {
    left: ExpressionRef;
    right: ExpressionRef;
  }

  interface TryInfo extends ExpressionInfo {
    name: string;
    body: ExpressionRef;
    catchTags: string[];
    catchBodies: ExpressionRef[];
    hasCatchAll: boolean;
    delegateTarget: string;
    isDelegate: boolean;
  }

  interface ThrowInfo extends ExpressionInfo {
    tag: string;
    operands: ExpressionRef[];
  }

  interface RethrowInfo extends ExpressionInfo {
    target: string;
  }

  interface TupleMakeInfo extends ExpressionInfo {
    operands: ExpressionRef[];
  }

  interface TupleExtract extends ExpressionInfo {
    tuple: ExpressionRef;
    index: number;
  }

  interface I31NewInfo extends ExpressionInfo {
    value: ExpressionRef;
  }

  interface I31GetInfo extends ExpressionInfo {
    i31: ExpressionRef;
    isSigned: boolean;
  }

  function getFunctionInfo(func: FunctionRef): FunctionInfo;

  interface FunctionInfo {
    name: string;
    module: string | null;
    base: string | null;
    params: Type;
    results: Type;
    vars: Type[];
    body: ExpressionRef;
  }

  function getGlobalInfo(global: GlobalRef): GlobalInfo;

  interface GlobalInfo {
    name: string;
    module: string | null;
    base: string | null;
    type: Type;
    mutable: boolean;
    init: ExpressionRef;
  }

  function getTableInfo(table: TableRef): TableInfo;

  interface TableInfo {
    name: string;
    module: string | null;
    base: string | null;
    initial: number;
    max?: number;
  }

  function getElementSegmentInfo(segment: ElementSegmentRef): ElementSegmentInfo;

  interface ElementSegmentInfo {
    name: string,
    table: string,
    offset: number,
    data: string[]
  }

  function getTagInfo(tag: TagRef): TagInfo;

  interface TagInfo {
    name: string;
    module: string | null;
    base: string | null;
    params: Type;
    results: Type;
  }

  function getExportInfo(export_: ExportRef): ExportInfo;

  interface ExportInfo {
    kind: ExternalKinds;
    name: string;
    value: string;
  }

  function getSideEffects(expr: ExpressionRef, features: Features): SideEffects;

  const enum SideEffects {
    None,
    Branches,
    Calls,
    ReadsLocal,
    WritesLocal,
    ReadsGlobal,
    WritesGlobal,
    ReadsMemory,
    WritesMemory,
    ReadsTable,
    WritesTable,
    ImplicitTrap,
    IsAtomic,
    Throws,
    DanglingPop,
    TrapsNeverHappen,
    Any
  }

  function emitText(expression: ExpressionRef | Module): string;
  function readBinary(data: Uint8Array): Module;
  function parseText(text: string): Module;
  function getOptimizeLevel(): number;
  function setOptimizeLevel(level: number): number;
  function getShrinkLevel(): number;
  function setShrinkLevel(level: number): number;
  function getDebugInfo(): boolean;
  function setDebugInfo(on: boolean): void;
  function getLowMemoryUnused(): boolean;
  function setLowMemoryUnused(on: boolean): void;
  function getZeroFilledMemory(): boolean;
  function setZeroFilledMemory(on: boolean): void;
  function getFastMath(): boolean;
  function setFastMath(on: boolean): void;
  function getPassArgument(key: string): string | null;
  function setPassArgument(key: string, value: string | null): void;
  function clearPassArguments(): void;
  function getAlwaysInlineMaxSize(): number;
  function setAlwaysInlineMaxSize(size: number): void;
  function getFlexibleInlineMaxSize(): number;
  function setFlexibleInlineMaxSize(size: number): void;
  function getOneCallerInlineMaxSize(): number;
  function setOneCallerInlineMaxSize(size: number): void;
  function getAllowInliningFunctionsWithLoops(): boolean;
  function setAllowInliningFunctionsWithLoops(on: boolean): void;
  function exit(status: number): void;

  type RelooperBlockRef = number;

  class Relooper {
    constructor(module: Module);
    addBlock(expression: ExpressionRef): RelooperBlockRef;
    addBranch(from: RelooperBlockRef, to: RelooperBlockRef, condition: ExpressionRef, code: ExpressionRef): void;
    addBlockWithSwitch(code: ExpressionRef, condition: ExpressionRef): RelooperBlockRef;
    addBranchForSwitch(from: RelooperBlockRef, to: RelooperBlockRef, indexes: number[], code: ExpressionRef): void;
    renderAndDispose(entry: RelooperBlockRef, labelHelper: number): ExpressionRef;
  }

  class ExpressionRunner {
    constructor(module: Module, flags: ExpressionRunnerFlags, maxDepth: number, maxLoopIterations: number);
    setLocalValue(index: number, valueExpr: ExpressionRef): boolean;
    setGlobalValue(name: string, valueExpr: ExpressionRef): boolean;
    runAndDispose(expr: ExpressionRef): ExpressionRef;
  }
}

declare const binaryen: typeof Binaryen;

export default binaryen;
