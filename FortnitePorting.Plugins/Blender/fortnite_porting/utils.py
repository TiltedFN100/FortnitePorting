import bpy
import os
from math import radians
from mathutils import Matrix, Vector, Euler, Quaternion


def ensure_blend_data():
    addon_dir = os.path.dirname(os.path.splitext(__file__)[0])
    with bpy.data.libraries.load(os.path.join(addon_dir, "data", "fortnite_porting_data.blend")) as (data_from, data_to):
        for node_group in data_from.node_groups:
            if not bpy.data.node_groups.get(node_group):
                data_to.node_groups.append(node_group)

        for mat in data_from.materials:
            if not bpy.data.materials.get(mat):
                data_to.materials.append(mat)

        for obj in data_from.objects:
            if not bpy.data.objects.get(obj):
                data_to.objects.append(obj)

def hash_code(num):
    return hex(abs(num))[2:]


def first(target, expr, default=None):
    if not target:
        return None
    filtered = filter(expr, target)

    return next(filtered, default)


def where(target, expr):
    if not target:
        return []
    filtered = filter(expr, target)

    return list(filtered)


def any(target, expr):
    if not target:
        return False

    filtered = list(filter(expr, target))
    return len(filtered) > 0


def add_unique(target, item):
    if item in target:
        return

    target.append(item)


def add_range(target, items):
    for item in items:
        target.add(items)

def get_case_insensitive(source, string):
    for item in source:
        if item.name.casefold() == string.casefold():
            return item
    return None
